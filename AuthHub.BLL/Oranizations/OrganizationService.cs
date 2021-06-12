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
                Name = request.Name,
                Email = request.Email
            };
            await _organizationLoader.Create(org);
            return org;
        }

        public async Task<Organization> Get(Guid organizationId)
            => await _organizationLoader.Get(organizationId);

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
            => await _organizationLoader.GetSettings(organizationId, name);

        public async Task<(bool, Organization)> Update(Organization request)
            => await _organizationLoader.Update(request);

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
            => await _organizationLoader.UpdateSettings(organizationId, request);
    }
}
