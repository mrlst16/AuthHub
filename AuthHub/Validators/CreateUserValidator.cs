using AuthHub.Models.Users;
using FluentValidation;

namespace AuthHub.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public const string IncludeValidatePassword = "ValidatePassword";
        public CreateUserValidator()
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
