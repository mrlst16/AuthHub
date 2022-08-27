﻿using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthHub.Models.Requests;

namespace AuthHub.BLL.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubOrganizationLoader _authHubOrganizationLoader;
        private readonly IPasswordLoader _passwordLoader;
        private readonly IConfiguration _configuration;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;

        public OrganizationService(
            IOrganizationLoader organizationLoader,
            IUserLoader userLoader,
            IAuthHubOrganizationLoader authHubOrganizationLoader,
            IPasswordLoader passwordLoader,
            IConfiguration configuration,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory
            )
        {
            _organizationLoader = organizationLoader;
            _userLoader = userLoader;
            _authHubOrganizationLoader = authHubOrganizationLoader;
            _passwordLoader = passwordLoader;
            _configuration = configuration;
            _tokenGeneratorFactory = tokenGeneratorFactory;
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
            var authSettingsId = _configuration.AuthHubSettingsId();

            var passwordRequest = new PasswordRequest()
            {
                UserName = request.Name,
                OrganizationID = authHubOrg.ID,
                Password = request.Password,
                SettingsName = "audder_clients"
            };
            var user = new User()
            {
                AuthSettingsId = authSettingsId,
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.Name,
                LastName = org.Name,
                Password = new Models.Passwords.Password()
                {
                    Claims = new List<ClaimsEntity>()
                    {
                        new ClaimsEntity("role", "admin", authSettingsId)
                    }
                }
            };

            ITokenGenerator tokenGenerator = _tokenGeneratorFactory(AuthSchemeEnum.JWT);

            (user.Password.PasswordHash, user.Password.Salt) = await tokenGenerator.NewHash(passwordRequest, authHubOrg);

            await _userLoader.Create(authHubOrg.ID, passwordRequest.SettingsName, user);
            user.Password.UserId = user.ID;

            await _passwordLoader.Set(passwordRequest.OrganizationID, passwordRequest.SettingsName, user.Password);
            return org;
        }

        public async Task<Organization> Get(Guid organizationId)
            => await _organizationLoader.Get(organizationId);

        public async Task<Organization> Get(string name)
            => await _organizationLoader.Get(name);

        public async Task<IList<Organization>> GetAll()
            => await _organizationLoader.GetAll();

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
            => await _organizationLoader.GetSettings(organizationId, name);

        public async Task<(bool, Organization)> Update(Organization request)
            => await _organizationLoader.Update(request);

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
            => await _organizationLoader.UpdateSettings(organizationId, request);
    }
}