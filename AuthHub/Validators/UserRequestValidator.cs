using AuthHub.Models.Users;
using FluentValidation;
using System;

namespace AuthHub.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.OrganizationID)
                .NotEmpty()
                .NotNull()
                .Must(x => x != Guid.Empty)
                .WithMessage("OrganizationID must be populated");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("UserName must be populated");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password must be populated");
        }
    }
}
