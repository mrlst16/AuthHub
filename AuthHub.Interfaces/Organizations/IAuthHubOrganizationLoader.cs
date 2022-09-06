using AuthHub.Models.Organizations;

namespace AuthHub.Interfaces.Organizations
{
    public interface IAuthHubOrganizationLoader
    {
        Task<Organization> CreateOrGetAuthHubOrganization();
    }
}
