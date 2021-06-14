using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public interface IOrganizationConnector
    {
        Task<Organization> CreateOrganization(CreateOrganizationRequest request);
        Task<AuthSettings> MergeAuthSettings(AuthSettings request);
        Task<Organization> GetOrganization(Guid organizationId);
        Task<AuthSettings> GetAuthSettings(Guid organizationId, string name);
    }
}
