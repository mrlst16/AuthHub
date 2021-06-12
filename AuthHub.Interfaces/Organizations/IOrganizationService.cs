using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Task<Organization> Create(CreateOrganizationRequest request);
        Task<Organization> Get(Guid organizationId);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request);
        Task<AuthSettings> GetSettings(Guid organizationId, string name);
    }
}