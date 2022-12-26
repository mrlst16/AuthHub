using AuthHub.Models.Constants;
using Microsoft.Extensions.Configuration;

namespace AuthHub.SDK
{
    public abstract class ConnectorBase
    {
        protected readonly string _baseUrl;
        protected readonly Guid _authSettingsId;
        protected readonly string _apiKey;
        protected readonly string _apiSecret;

        protected ConnectorBase(
            string baseUrl,
            Guid authSettingsId,
            string apiKey,
            string apiSecret
            )
        {
            _baseUrl = baseUrl;
            _authSettingsId = authSettingsId;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        protected ConnectorBase(
            IConfiguration configuration
            )
        {
            var section = configuration.GetSection("AuthHub:API");
            _authSettingsId = section.GetValue<Guid>("AuthSettingsId");
            _apiKey = section.GetValue<string>("APIKey");
            _apiSecret = section.GetValue<string>("APISecret");
        }

        protected HttpClient Client
        {
            get
            {
                HttpClient result = new HttpClient();
                result.DefaultRequestHeaders.Add(AuthHubHeaders.AuthSettingsID, _authSettingsId.ToString());
                result.DefaultRequestHeaders.Add(AuthHubHeaders.APIKey, _apiKey);
                result.DefaultRequestHeaders.Add(AuthHubHeaders.APISecret, _apiSecret);
                result.DefaultRequestHeaders.Add("Content-Type", "application/json");
                return result;
            }
        }
    }
}