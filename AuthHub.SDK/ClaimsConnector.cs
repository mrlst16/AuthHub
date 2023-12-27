using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Requests;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthHub.SDK
{
    public class ClaimsConnector : ConnectorBase, IClaimsConnector
    {
        public ClaimsConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret, Guid organizationId) 
            : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public ClaimsConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task SetClaims(SetClaimsRequest request)
        {
            await Client.PostAsJsonAsync("api/claims/set", request);
        }
    }
}
