using AuthHub.Models.Users;
using FluentValidation;

namespace AuthHub.Api.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public const string IncludeValidatePassword = "ValidatePassword";
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("UserName must be populated");

            RuleSet(IncludeValidatePassword, () =>
            {
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Password must be populated");
            });
        }
    }
}
