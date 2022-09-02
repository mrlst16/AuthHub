using AuthHub.Models.Requests;
using FluentValidation;

namespace AuthHub.Api.Validators
{
    public class PasswordRequestValidator : AbstractValidator<PasswordRequest>
    {
        public PasswordRequestValidator()
        {

        }
    }
}
