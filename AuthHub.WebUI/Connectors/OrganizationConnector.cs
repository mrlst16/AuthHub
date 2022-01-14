using AuthHub.Models.Organizations;
using AuthHub.Models.Tokens;
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

        public async Task<AuthSettings> SaveAuthSettings(AuthSettings request)
        {
            var token = await GetToken();
            request.OrganizationID = token.EntityID;
            return await _connector.Post<AuthSettings, AuthSettings>("organization/save_auth_settings", request);
        }

        public async Task<Organization> CreateOrganization(CreateOrganizationRequest request)
            => await _connector.Post<CreateOrganizationRequest, Organization>("organization/save_organization", request);

        public async Task<Organization> GetOrganization()
        {
            var token = await GetToken();
            var response = await _connector.Get<Organization>("organization/get_organization", new Dictionary<string, string>()
            {
                { "organizationId", token.EntityID.ToString()}
            });
            return response;
        }

        private async Task<Token> GetToken()
        {
            var token = await _tokenConnector.GetTokenFromLocalStorage();
            if (token == null)
            {
                _navigationManager.NavigateTo("/organization_signin");
                return null;
            }
            return token;
        }

        public async Task<AuthSettings> GetAuthSettings(string name)
        {
            var token = await GetToken();

            var response = await _connector.Get<AuthSettings>("organization/get_auth_settings", new Dictionary<string, string>()
            {
                { "organizationId", token.EntityID.ToString()},
                { "name", name}
            });
            return response;
        }
    }
}