using AuthHub.Models.Passwords;
using FluentValidation;

namespace AuthHub.Validators
{
    public class PasswordRequestValidator : AbstractValidator<PasswordRequest>
    {
        public PasswordRequestValidator()
        {

        }
    }
}
