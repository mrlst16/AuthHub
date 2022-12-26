using AuthHub.Models.Entities.Tokens;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using AuthHub.Models.Constants;

namespace AuthHub.SDK
{
    public class TokenConnector : ConnectorBase, ITokenConnector
    {

        public TokenConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret) : base(baseUrl, authSettingsId, apiKey, apiSecret)
        {
        }

        public TokenConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Token> GetJWTTokenAsnyc(string username, string password)
        {
            HttpClient client = Client;
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Username, username);
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Password, password);

            HttpResponseMessage response = await client.GetAsync("api/token/JWTUserToken");
            string responseString = await response.Content.ReadAsStringAsync();

            Token result = JsonSerializer.Deserialize<Token>(responseString)
                           ?? throw new Exception("Could not deserialize response body");
            return result;
        }
    }
}
