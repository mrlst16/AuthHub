using AuthHub.Models.Organizations;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IAuthHubOrganizationLoader
    {
        Task<Organization> CreateOrGetAuthHubOrganization();
    }
}
