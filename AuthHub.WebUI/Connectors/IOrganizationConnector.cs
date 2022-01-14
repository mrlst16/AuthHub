using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public interface IOrganizationConnector
    {
        Task<Organization> CreateOrganization(CreateOrganizationRequest request);
        Task<AuthSettings> SaveAuthSettings(AuthSettings request);
        Task<Organization> GetOrganization();
        Task<Organization> GetOrganization(string organizationId);
        Task<AuthSettings> GetAuthSettings(string name);
    }
}
