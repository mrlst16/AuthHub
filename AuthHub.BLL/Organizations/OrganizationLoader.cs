using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Organizations
{
    public class OrganizationLoader : IOrganizationLoader
    {
        private readonly IOrganizationContext _organizationContext;

        public OrganizationLoader(
            IOrganizationContext organizationContext
            )
        {
            _organizationContext = organizationContext;
        }

        public async Task Create(Organization request)
            => await _organizationContext.Create(request);

        public async Task<Organization> Get(Guid id)
            => await _organizationContext.Get(id);

        public async Task<Organization> Get(string name)
            => await _organizationContext.Get(name);

        public async Task<IList<Organization>> GetAll()
            => await _organizationContext.GetAll();

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
            => await _organizationContext.GetSettings(organizationId, name);

        public async Task<(bool, Organization)> Update(Organization request)
            => await _organizationContext.Update(request);

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
            => await _organizationContext.UpdateSettings(organizationId, request);
    }
}
