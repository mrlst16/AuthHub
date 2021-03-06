using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using FluentValidation;

namespace AuthHub.Validators
{
    public class CreateOrganizationRequestValidator : AbstractValidator<CreateOrganizationRequest>
    {
        private readonly IOrganizationService _organizationService;

        public CreateOrganizationRequestValidator(
            IOrganizationService organizationService
            )
        {
            _organizationService = organizationService;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .MustAsync(async (x, c) => (await organizationService.Get(x)) == null)
                .WithMessage("Organization already exists");

            RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword)
                .WithMessage("Password and Confirm Password do not match");
        }
    }
}
