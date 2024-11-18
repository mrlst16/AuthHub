using AuthHub.Models.Constants;
using AuthHub.Models.Tokens;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Common.Models.Responses;
using AuthHub.Models.Entities.Users;

namespace AuthHub.SDK.Connectors
{
    public class TokenConnector : ConnectorBase, ITokenConnector
    {

        public TokenConnector(string baseUrl, int authSettingsId, string apiKey, string apiSecret, int organizationId)
            : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public TokenConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ApiResponse<Token>> GetTokenAsync(string username, string password)
        {
            HttpClient client = Client;
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Username, username);
            client.DefaultRequestHeaders.Add(AuthHubHeaders.Password, password);
            var headers = client.DefaultRequestHeaders.Select(x => new
            {
                x.Key,
                Value = x.Value.First()
            });
            HttpResponseMessage response = await client.GetAsync("api/token");
            string responseString = await response.Content.ReadAsStringAsync();

            return await Deserialize<Token>(response);
        }

        public async Task<ApiResponse<Token>> RefreshTokenAsync(int userId, string refreshToken)
        {
            var path = $"api/token/refresh?refreshToken={refreshToken}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<Token>(response);
        }

        public async Task<ApiResponse<Token>> GetUserTokenPhoneLogin(string phoneNumber, string verificationCode)
        {
            var path = $"api/token/JWTUserTokenPhoneLogin?phoneNumber={phoneNumber}&verificationCode={verificationCode}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<Token>(response);
        }
    }
}
