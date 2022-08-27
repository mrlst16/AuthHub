using AuthHub.Models.Requests;
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
