using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public IOrganizationService _organizationService { get; set; }

        public OrganizationValidator(
            IOrganizationService organizationService
            )
        {
            _organizationService = organizationService;

            var organizations = Task.Run(() => _organizationService.GetAll()).Result;
            var organizationNames = organizations.Select(x => x.Name);

            RuleFor(x => x.Name)
                .MustAsync(async (x, y, z) => !organizationNames.Contains(y))
                .WithMessage((x, y) => $"An orgnization with the name {x.Name} already exists");
        }
    }
}
