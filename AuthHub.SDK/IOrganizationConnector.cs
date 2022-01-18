using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IOrganizationConnector
    {
        Task<Organization> CreateOrganization(CreateOrganizationRequest request);
        Task SaveAuthSettings(AuthSettings request);
        Task<Organization> GetOrganization();
        Task<Organization> GetOrganization(string organizationId);
        Task<AuthSettings> GetAuthSettings(string name);
    }
}
