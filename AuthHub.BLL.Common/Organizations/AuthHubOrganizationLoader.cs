using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Oranizations
{
    public class AuthHubOrganizationLoader : IAuthHubOrganizationLoader
    {
        ICrudRepositoryFactory _crudRepositoryFactory;
        IConfiguration _configuration;
        public AuthHubOrganizationLoader(
            ICrudRepositoryFactory crudRepositoryFactory,
            IConfiguration configuration
            )
        {
            _crudRepositoryFactory = crudRepositoryFactory;
            _configuration = configuration;
        }

        public async Task<Organization> CreateOrGetAuthHubOrganization()
        {
            Organization result = null;

            var repo = _crudRepositoryFactory.Get<Organization>();
            var (authHubOrgId, authHubIssuer, authHubKey) = _configuration.AuthHubAuthInfo();
            result = await repo.First(x => x.ID == authHubOrgId);
            if (result != null)
                return result;
            result = new Organization()
            {
                Email = "mrlst16@mail.rmu.edu",
                Name = "audder",
                ID = authHubOrgId,
                Settings = new List<AuthSettings>()
                    {
                        new AuthSettings()
                        {
                            Issuer = authHubIssuer,
                            Key = authHubIssuer,
                            Iterations = 10,
                            AuthScheme = AuthSchemeEnum.JWT,
                            SaltLength = 8,
                            HashLength = 8,
                            ClaimsKeys = new List<string>(){"role"},
                            ExpirationMinutes = 120,
                            Name = "audder_clients",
                            OrganizationID = authHubOrgId,
                            Users = new List<User>()
                        }
                    }
            };
            await repo.Create(result);

            return result;
        }
    }
}
