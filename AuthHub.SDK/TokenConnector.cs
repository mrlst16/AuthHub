﻿using AuthHub.Models.Constants;
using AuthHub.Models.Tokens;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Common.Models.Responses;

namespace AuthHub.SDK
{
    public class TokenConnector : ConnectorBase, ITokenConnector
    {

        public TokenConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret)
            : base(baseUrl, authSettingsId, apiKey, apiSecret)
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

            ApiResponse<Token> result = JsonSerializer
                                            .Deserialize<ApiResponse<Token>>(
                                                responseString, 
                                                    new JsonSerializerOptions()
                                                    {
                                                        PropertyNameCaseInsensitive = true
                                                    }
                                                )
                           ?? throw new Exception("Could not deserialize response body");
            return result.Data;
        }

        public async Task<Token> RefreshJWTTokenAsnyc(Guid userId, string refreshToken)
        {
            var path = $"api/token/RefreshJWTUserToken?userId={userId}&refreshToken={refreshToken}";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();

            Token result = JsonSerializer.Deserialize<Token>(responseString)
                           ?? throw new Exception("Could not deserialize response body");
            return result;
        }
    }
}
