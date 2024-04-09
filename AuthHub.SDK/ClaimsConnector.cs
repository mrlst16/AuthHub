using AuthHub.Models.Requests;
using AuthHub.SDK.Interfaces;
using AuthHub.SDK.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace AuthHub.SDK
{
    public class ClaimsConnector : ConnectorBase, IClaimsConnector
    {
        public ClaimsConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret, Guid organizationId)
            : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public ClaimsConnector(IOptions<AuthHubConnectorOptions> options)
            : base(options)
        {
        }

        public async Task SetClaims(SetClaimsRequest request)
        {
            await Client.PostAsJsonAsync("api/claims/set", request);
        }
    }
}
