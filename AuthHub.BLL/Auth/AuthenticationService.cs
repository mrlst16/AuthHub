using AuthHub.Interfaces.Auth;
using AuthHub.Models.Users;
using Common.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISRDRepository<User, Guid> _usersRepo;

        public AuthenticationService(
            ISRDRepository<User, Guid> usersRepo
            )
        {
            _usersRepo = usersRepo;
        }

        public async Task<bool> AuthenticateOrganization(Guid organizationId, string username, string password)
        {

            return false;
        }
    }
}
