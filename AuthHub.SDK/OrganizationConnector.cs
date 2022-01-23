using AuthHub.Models.Organizations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class OrganizationConnector : IOrganizationConnector
    {
        private readonly IApiConnector _connector;

        public OrganizationConnector(
            IApiConnector connector
            )
        {
            _connector = connector;
        }

        public async Task CreateOrganization(CreateOrganizationRequest request)
            => await _connector.Post<CreateOrganizationRequest>("organization/create_organization", request);

        public async Task<AuthSettings> GetAuthSettings(string name)
        {
            var token = await _connector.GetTokenFromLocalStorage();

            var response = await _connector.Get<AuthSettings>("organization/get_auth_settings", new Dictionary<string, string>()
            {
                { "organizationId", token.EntityID.ToString()},
                { "name", name}
            });
            return response;
        }

        public async Task SaveAuthSettings(AuthSettings request)
            => await _connector.Put<AuthSettings>("organization/save_auth_settings", request);

        public async Task<Organization> GetOrganization()
        {
            var token = await _connector.GetTokenFromLocalStorage();
            return await GetOrganization(token.EntityID.ToString());
        }

        public async Task<Organization> GetOrganization(string organizationId)
        {
            var response = await _connector.Get<Organization>("organization/get_organization", new Dictionary<string, string>()
            {
                { "organizationId", organizationId}
            });
            return response;
        }
    }
}