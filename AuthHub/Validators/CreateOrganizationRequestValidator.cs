using System.Collections.Generic;
using System.Linq;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Requests;
using FluentValidation;

namespace AuthHub.Api.Validators
{
    public class CreateOrganizationRequestValidator : AbstractValidator<CreateOrganizationRequest>
    {
        private List<char> SpecialChars = new List<char>()
        {
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')'
        };

        public CreateOrganizationRequestValidator(
            IOrganizationContext context
            )
        {
            //we want to make sure that
            //1) The organization doesn't exist already
            //2) The password is long enough and has at least 1 special char, 1 number and 1 capital letter
            //3) Password and confirm password match

            RuleFor(x => x.Name)
                .MustAsync(async (x, c) => !(await context.OrganizationExistsAsync(x)))
                .WithMessage("An organization with that name already exists");
            
            RuleFor(x => x)
                .Must((x, c, vc)=> PasswordMeetsRequirements(x.Password, vc));

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(x => x.Email)
                .Must(x => x.Contains("@"))
                .WithMessage("Email is not valid");

            RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword)
                .WithMessage("Confirm Password must match password");
            
        }

        private bool PasswordMeetsRequirements(
            string password,
            ValidationContext<CreateOrganizationRequest> context)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(password))
            {
                context.AddFailure("Password cannot be empty");
                result = false;
            }

            if (password.Length < 8)
            {
                context.AddFailure("Password must be at least 8 characters long");
                result = false;
            }

            if (!password.Any(x => char.IsUpper(x)))
            {
                context.AddFailure("Password must contain at least on upper-case letter");
                result = false;
            }

            if (!password.Any(x => char.IsNumber(x)))
            {
                context.AddFailure("Password must contain at least 1 number");
                result = false;
            }

            if (!password.Any(x => SpecialChars.Contains(x)))
            {
                context.AddFailure("Password must contain at least 1 special character");
                result = false;
            }
            return result;
        }
    }
}
