using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Auth;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Common.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.BLL.Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISRDRepository<User, Guid> _usersRepo;
        private readonly ISRDRepository<Password, Guid> _passwordRepo;
        private readonly JWTTokenGenerator _jwtGenerator;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            ISRDRepository<User, Guid> usersRepo,
            ISRDRepository<Password, Guid> passwordRepo,
            JWTTokenGenerator jwtGenerator,
            IConfiguration configuration
            )
        {
            _usersRepo = usersRepo;
            _passwordRepo = passwordRepo;
            _jwtGenerator = jwtGenerator;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateOrganization(string username, string password)
        {
            var authHubOrgId = _configuration.AuthHubOrganizationId();
            var users = await _usersRepo.ReadAsync(x =>
                (x.IsOrganization ?? false)
                    && x.UsersOrganizationId == authHubOrgId
                    && x.UserName == username);

            var user = users.FirstOrDefault();
            if (user == null)
                return false;

            var passwordsOnFile = await _passwordRepo.ReadAsync(x => x.UserId == user.Id);
            var passwordOnFile = passwordsOnFile.FirstOrDefault();
            if (passwordOnFile == null)
                return false;

            return _jwtGenerator.Authenticate(passwordOnFile.PasswordHash, password, passwordOnFile.Salt, 10);
        }
    }
}
