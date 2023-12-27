using AuthHub.Models.Constants;
using AuthHub.Models.Tokens;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Common.Models.Responses;

namespace AuthHub.SDK
{
    public class TokenConnector : ConnectorBase, ITokenConnector
    {

        public TokenConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret, Guid organizationId)
            : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public TokenConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Token> GetJWTTokenAsync(string username, string password)
        {
            HttpClient client = Client;
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Username, username);
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Password, password);

            HttpResponseMessage response = await client.GetAsync("api/token/JWTUserToken");
            string responseString = await response.Content.ReadAsStringAsync();

            return await Deserialize<Token>(response);
        }

        public async Task<Token> RefreshJWTTokenAsync(Guid userId, string refreshToken)
        {
            var path = $"api/token/RefreshJWTUserToken?userId={userId}&refreshToken={refreshToken}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<Token>(response);
        }
    }
}
