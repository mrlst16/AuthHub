﻿using AuthHub.Models.Organizations;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class OrganizationConnector : IOrganizationConnector
    {
        private readonly IApiConnector _connector;
        private readonly ITokenConnector _tokenConnector;
        private readonly NavigationManager _navigationManager;

        public OrganizationConnector(
            IApiConnector connector,
            ITokenConnector tokenConnector,
            NavigationManager navigationManager
            )
        {
            _connector = connector;
            _tokenConnector = tokenConnector;
            _navigationManager = navigationManager;
        }

        public async Task<AuthSettings> MergeAuthSettings(AuthSettings request)
            => await _connector.Post<AuthSettings, AuthSettings>("merge_auth_settings", request);

        public async Task<Organization> CreateOrganization(CreateOrganizationRequest request)
            => await _connector.Post<CreateOrganizationRequest, Organization>("create_organization", request);

        public async Task<Organization> GetOrganization()
        {
            var token = await _tokenConnector.GetTokenFromLocalStorage();
            if (token == null)
            {
                _navigationManager.NavigateTo("/organization_signin");
                return null;
            }
            var response = await _connector.Get<Organization>("get_organization", new Dictionary<string, string>()
            {
                { "organizationId", token.EnitityID.ToString()}
            });
            return response;
        }

        public async Task<AuthSettings> GetAuthSettings(string name)
        {
            var token = await _tokenConnector.GetTokenFromLocalStorage();
            if (token == null)
            {
                _navigationManager.NavigateTo("/organization_signin");
                return null;
            }
            var response = await _connector.Get<AuthSettings>("get_auth_settings", new Dictionary<string, string>()
            {
                { "organizationId", token.EnitityID.ToString()},
                { "name", name}
            });
            return response;
        }
    }
}