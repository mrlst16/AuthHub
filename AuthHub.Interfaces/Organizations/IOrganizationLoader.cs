using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationLoader
    {
        Task Create(Organization request);
        Task<Organization> Get(Guid id);
        Task<AuthSettings> GetSettings(Guid organizationId, string name);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request);
    }
}