using Microsoft.Extensions.Options;

namespace AuthHub.SDK.Options
{
    public class AuthHubConnectorOptions
    {
        public Guid AuthSettingsId { get; set; }
        public string APIKey { get; set; }
        public string APISecret { get; set; }
        public Guid OrganizationId { get; set; }
        public string BaseUrl { get; set; }
    }
}