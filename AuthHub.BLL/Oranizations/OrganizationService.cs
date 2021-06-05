using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Oranizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationLoader _organizationLoader;

        public OrganizationService(
            IOrganizationLoader organizationLoader
            )
        {
            _organizationLoader = organizationLoader;
        }

        public async Task<Organization> Create(CreateOrganizationRequest request)
        {
            var org = new Organization()
            {
                ID = Guid.NewGuid(),
                Name = request.Name
            };
            await _organizationLoader.Create(org);
            return org;
        }

        public async Task<(bool, Organization)> Update(Organization request)
            => await _organizationLoader.Update(request);

        public async Task<(bool, OrganizationSettings)> UpdateSettings(Guid organizationId, OrganizationSettings request)
            => await _organizationLoader.UpdateSettings(organizationId, request);
    }
}
