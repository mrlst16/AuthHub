using AuthHub.Models.Constants;
using AuthHub.Models.Responses;
using Common.Models.Responses;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace AuthHub.SDK
{
    public abstract class ConnectorBase
    {
        protected readonly string _baseUrl;
        protected readonly Guid _authSettingsId;
        protected readonly string _apiKey;
        protected readonly string _apiSecret;
        protected readonly Guid _organizationId;

        protected ConnectorBase(
            string baseUrl,
            Guid authSettingsId,
            string apiKey,
            string apiSecret,
            Guid organizationId
            )
        {
            _baseUrl = baseUrl;
            _authSettingsId = authSettingsId;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _organizationId = organizationId;
        }

        protected ConnectorBase(
            IConfiguration configuration
            )
        {
            var section = configuration.GetSection("AuthHub:API");
            _authSettingsId = section.GetValue<Guid>("AuthSettingsId");
            _apiKey = section.GetValue<string>("APIKey");
            _apiSecret = section.GetValue<string>("APISecret");
            _organizationId = section.GetValue<Guid>("OrganizationId");
        }

        protected HttpClient Client
        {
            get
            {
                HttpClient result = new HttpClient();
                result.BaseAddress = new Uri(_baseUrl);
                result.DefaultRequestHeaders.Add(AuthHubHeaders.AuthSettingsID, _authSettingsId.ToString());
                result.DefaultRequestHeaders.Add(AuthHubHeaders.APIKey, _apiKey);
                result.DefaultRequestHeaders.Add(AuthHubHeaders.APISecret, _apiSecret);
                result.DefaultRequestHeaders.Add(AuthHubHeaders.OrganizationID, _organizationId.ToString());
                return result;
            }
        }

        protected async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            string responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<T>>(
                responseString,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            return result.Data;
        }
    }
}