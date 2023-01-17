using AuthHub.Interfaces.Users;
using AuthHub.Models.Requests;
using Common.Interfaces.Providers;
using FluentValidation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuthHub.Api.Validators
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        private readonly IUserLoader _userLoader;
        private readonly IDateProvider _dateProvider;

        public ResetPasswordRequestValidator(
            IUserLoader userLoader,
            IDateProvider dateProvider
            )
        {
            _userLoader = userLoader;
            _dateProvider = dateProvider;

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(APIErrorCodes.UserIdNullOrEmpty)
                .WithMessage("UserId is null or empty");

            RuleFor(x => x)
                .MustAsync(async (x, y, b, c)
                    => await ValidationTokenExistsAndIsStillValid(x, y, b, c));
        }

        private async Task<bool> ValidationTokenExistsAndIsStillValid(
            ResetPasswordRequest request,
            ResetPasswordRequest notSureWhyThisIsAVariable,
            ValidationContext<ResetPasswordRequest> context,
            CancellationToken cancellationToken
            )
        {
            var user = await _userLoader.GetAsync(request.UserId);

            if (user == null)
            {
                context.AddFailure("User not available");
                return false;
            }
            var code = user.PasswordResetTokens.FirstOrDefault(x => x.VerificationCode == request.VerificationCode);
            if (code == null)
            {
                context.AddFailure($"VerificationCode {request.VerificationCode} does not exist");
                return false;
            }

            if (code.ExpirationDate < _dateProvider.UTCNow)
            {
                context.AddFailure("VerificationCode is expired");
                return false;
            }

            return true;
        }
    }
}
