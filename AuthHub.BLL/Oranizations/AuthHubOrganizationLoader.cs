using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Oranizations
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
            var authHubOrgId = _configuration.GetValue<Guid>("AppSettings:AuthHubOrganiztionID");
            var authHubIssuer = _configuration.GetValue<string>("AppSettings:AuthHubIssuer");
            var authHubKey = _configuration.GetValue<string>("AppSettings:AuthHubKey");
            result = await repo.First(x => x.ID == authHubOrgId);
            if (result != null)
                return result;
            result = new Organization()
            {
                Email = "mrlst16@mail.rmu.edu",
                Name = "audder",
                ID = authHubOrgId,
                Settings = new System.Collections.Generic.List<AuthSettings>()
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
