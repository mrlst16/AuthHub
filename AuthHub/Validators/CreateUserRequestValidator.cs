using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using FluentValidation;

namespace AuthHub.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public const string IncludeValidatePassword = "ValidatePassword";
        private readonly IUserLoader _userLoader;

        public CreateUserRequestValidator(
            IUserLoader userLoader
            )
        {
            _userLoader = userLoader;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithErrorCode(ErrorCodes.PropertyMissing)
                .WithMessage("UserName must be populated");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithErrorCode(ErrorCodes.PropertyMissing)
                .WithMessage("Password must be populated");

            RuleFor(x => x)
                .MustAsync(
                    async (request, token) =>
                        await _userLoader.UsernameAvailable(request.AuthSettingsId, request.UserName)
                        )
                .WithErrorCode(ErrorCodes.UserAlreadyExists)
                .WithMessage("Username is not available");
        }
    }
}
