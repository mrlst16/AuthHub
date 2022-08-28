using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;

namespace AuthHub.DAL.EntityFramework.Organizations
{
    public class OrganizationContext : IOrganizationContext
    {
        public Task Create(Organization request)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthSettings> GetSettings(Guid organizationId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, Organization)> Update(Organization request)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthSettings> GetSettings(Guid authSettingsId)
        {
            throw new NotImplementedException();
        }
    }
}
