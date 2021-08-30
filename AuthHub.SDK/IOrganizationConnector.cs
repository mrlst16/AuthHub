using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IOrganizationConnector
    {
        Task<Organization> CreateOrganization(CreateOrganizationRequest request);
        Task<AuthSettings> MergeAuthSettings(AuthSettings request);
        Task<Organization> GetOrganization(Action ifNoTokenPresent);
        Task<AuthSettings> GetAuthSettings(string name, Action ifNoTokenPresent);
    }
}
