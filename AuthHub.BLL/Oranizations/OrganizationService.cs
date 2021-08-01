using AuthHub.BLL.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Oranizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubOrganizationLoader _authHubOrganizationLoader;

        public OrganizationService(
            IOrganizationLoader organizationLoader,
            IUserLoader userLoader,
            IAuthHubOrganizationLoader authHubOrganizationLoader
            )
        {
            _organizationLoader = organizationLoader;
            _userLoader = userLoader;
            _authHubOrganizationLoader = authHubOrganizationLoader;
        }

        public async Task<Organization> Create(CreateOrganizationRequest request)
        {
            var org = new Organization()
            {
                ID = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email
            };
            await _organizationLoader.Create(org);
            var authHubOrg = await _authHubOrganizationLoader.CreateOrGetAuthHubOrganization();

            var passwordRequest = new PasswordRequest()
            {
                UserName = request.Name,
                OrganizationID = authHubOrg.ID,
                Password = request.Password,
                SettingsName = "audder_clients"
            };
            var user = new User()
            {
                Email = request.Email,
                Password = new Models.Passwords.Password()
                {
                    UserName = request.Name,
                    HashLength = 8,
                    Iterations = 10,
                    Claims = new List<SerializableClaim>()
                    {
                        new SerializableClaim("role", "admin")
                    }
                },
                UserName = request.Name
            };

            JWTTokenGenerator tokenGenerator = new JWTTokenGenerator(_organizationLoader);

            var (passwordHash, salt) = await tokenGenerator.GetHash(passwordRequest, authHubOrg);
            user.Password.PasswordHash = passwordHash;
            user.Password.Salt = salt;

            await _userLoader.Create(authHubOrg.ID, passwordRequest.SettingsName, user);

            return org;
        }

        public async Task<Organization> Get(Guid organizationId)
            => await _organizationLoader.Get(organizationId);

        public async Task<Organization> Get(string name)
            => await _organizationLoader.Get(name);

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
            => await _organizationLoader.GetSettings(organizationId, name);

        public async Task<(bool, Organization)> Update(Organization request)
            => await _organizationLoader.Update(request);

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
            => await _organizationLoader.UpdateSettings(organizationId, request);
    }
}