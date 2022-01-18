using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class OrganizationConnector : IOrganizationConnector
    {
        private readonly IApiConnector _connector;
        private readonly ITokenConnector _tokenConnector;

        public OrganizationConnector(
            IApiConnector connector,
            ITokenConnector tokenConnector
            )
        {
            _connector = connector;
            _tokenConnector = tokenConnector;
        }

        public async Task<Organization> CreateOrganization(CreateOrganizationRequest request)
            => await _connector.Post<CreateOrganizationRequest, Organization>("create_organization", request);


        public async Task<AuthSettings> GetAuthSettings(string name)
        {
            var token = await _connector.GetTokenFromLocalStorage();

            var response = await _connector.Get<AuthSettings>("get_auth_settings", new Dictionary<string, string>()
            {
                { "organizationId", token.EntityID.ToString()},
                { "name", name}
            });
            return response;
        }

        public async Task SaveAuthSettings(AuthSettings request)
            => await _connector.Put<AuthSettings, bool>("/save_auth_settings", request);

        public async Task<Organization> GetOrganization()
        {
            var token = await _connector.GetTokenFromLocalStorage();
            var response = await _connector.Get<Organization>("get_organization", new Dictionary<string, string>()
            {
                { "organizationId", token.EntityID.ToString()}
            });
            return response;
        }

        public async Task<Organization> GetOrganization(string organizationId)
        {
            var response = await _connector.Get<Organization>("get_organization", new Dictionary<string, string>()
            {
                { "organizationId", organizationId}
            });
            return response;
        }
    }
}