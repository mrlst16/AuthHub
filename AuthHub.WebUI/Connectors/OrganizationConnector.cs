using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
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

        public async Task<AuthSettings> MergeAuthSettings(AuthSettings request)
            => await _connector.Post<AuthSettings, AuthSettings>("merge_auth_settings", request);

        public async Task<Organization> CreateOrganization(CreateOrganizationRequest request)
            => await _connector.Post<CreateOrganizationRequest, Organization>("create_organization", request);

        public async Task<Organization> GetOrganization(Guid organizationId)
        => await _connector.Get<Organization>("get_organization", new Dictionary<string, string>()
            {
                { "organizationId", organizationId.ToString()}
            });

        public async Task<AuthSettings> GetAuthSettings(Guid organizationId, string name)
            => await _connector.Get<AuthSettings>("get_auth_settings", new Dictionary<string, string>()
            {
                { "organizationId", organizationId.ToString()},
                { "name", name}
            });
    }
}
