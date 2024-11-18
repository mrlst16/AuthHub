using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Requests.Claims;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthHub.SDK.Connectors
{
    public class ClaimsConnector : ConnectorBase, IClaimsConnector
    {
        public ClaimsConnector(string baseUrl, int authSettingsId, string apiKey, string apiSecret, int organizationId)
            : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public ClaimsConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task SetClaimsAsync(SetClaimsRequest request)
        {
            await Client.PutAsJsonAsync("api/claims", request);
        }

        public async Task AddClaimsAsync(AddClaimsRequest request)
        {
            await Client.PostAsJsonAsync("api/claims", request);
        }

        public async Task RemoveClaimsAsync(RemoveClaimsRequest request)
        {
            await Client.PatchAsJsonAsync("api/claims", request);
        }
    }
}