﻿using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Enums;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Organizations
{
    public class AuthHubOrganizationLoader : IAuthHubOrganizationLoader
    {

        private readonly IConfiguration _configuration;
        private readonly IOrganizationContext _context;

        public AuthHubOrganizationLoader(
            IConfiguration configuration,
            IOrganizationContext context
            )
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<Organization> CreateOrGetAuthHubOrganization()
        {
            Organization result = null;

            var (authHubOrgId, authHubIssuer, authHubKey) = _configuration.AuthHubAuthInfo();
            result = await _context.Get(authHubOrgId);
            if (result != null)
                return result;
            result = new Organization()
            {
                Email = "mrlst16@mail.rmu.edu",
                Name = "audder",
                Id = authHubOrgId,
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
                            AvailableClaimsKeys = new List<ClaimsKey>(){_configuration.GetClaimsKey("role")},
                            ExpirationMinutes = 120,
                            Name = "audder_clients",
                            OrganizationID = authHubOrgId
                        }
                    }
            };
            await _context.Create(result);
            return result;
        }
    }
}
