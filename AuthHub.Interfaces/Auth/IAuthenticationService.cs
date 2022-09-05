using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Auth
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateOrganization(Guid organizationId, string username, string password);
    }
}
