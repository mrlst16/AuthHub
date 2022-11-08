using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using FluentValidation;
using System.Threading.Tasks;

namespace AuthHub.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IUserLoader _userLoader;
        public CreateUserRequestValidator(
            IUserLoader userLoader
            )
        {
            _userLoader = userLoader;

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username cannot be empty")
                .WithErrorCode(APIErrorCodes.FieldMissing);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .WithErrorCode(APIErrorCodes.FieldMissing);

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("FirstName cannot be empty")
                .WithErrorCode(APIErrorCodes.FieldMissing);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .WithErrorCode(APIErrorCodes.FieldMissing);

            RuleFor(x => x.Password)
                .Must(x => x.Length >= 8)
                .WithMessage("Password must be at least eight characters long")
                .WithErrorCode(APIErrorCodes.PasswordLengthTooShort);


            RuleFor(x => x.UserName)
                .MustAsync(async (x, c) => await UserNameAvailaible(x))
                .WithMessage("Username is already taken")
                .WithErrorCode(APIErrorCodes.UsernameUnavailable);
        }

        public async Task<bool> UserNameAvailaible(string userName)
        {
            try
            {
                var response = await _userLoader.GetAsync(userName);
                return response == null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
