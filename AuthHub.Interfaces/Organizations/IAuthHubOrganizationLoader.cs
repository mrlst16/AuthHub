using AuthHub.Models.Entities.Organizations;

namespace AuthHub.Interfaces.Organizations
{
    public interface IAuthHubOrganizationLoader
    {
        Task<Organization> CreateOrGetAuthHubOrganization();
    }
}
