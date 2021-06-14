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
        }
    }
}
