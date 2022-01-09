using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static Guid AuthHubOrganizationId(this IConfiguration configuration)
            => configuration.GetValue<Guid>("AppSettings:AuthHubOrganiztionID");
        public static string AuthHubIssuer(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubIssuer");
        public static string AuthHubKey(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubKey");
        public static string AuthHubSettingsId(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubSettingsId");

        public static (Guid, string, string) AuthHubAuthInfo(this IConfiguration configuration)
            => (configuration.AuthHubOrganizationId(), configuration.AuthHubIssuer(), configuration.AuthHubKey());
    }
}
