using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationLoader
    {
        Task Create(Organization request);
        Task<Organization> Get(Guid id);
        Task<OrganizationSettings> GetSettings(Guid organizationId, string name);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, OrganizationSettings)> UpdateSettings(Guid organizationId, OrganizationSettings request);
    }
}