using Microsoft.Extensions.Configuration;
using System;

namespace AuthHub.BLL.Extensions
{
    public static class ConfigurationExtensions
    {
        public static Guid AuthHubOrganizationId(this IConfiguration configuration)
            => configuration.GetValue<Guid>("AppSettings:AuthHubOrganiztionID");
        public static string AuthHubIssuer(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubIssuer");
        public static string AuthHubKey(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubKey");

        public static (Guid, string, string) AuthHubAuthInfo(this IConfiguration configuration)
            => (configuration.AuthHubOrganizationId(), configuration.AuthHubIssuer(), configuration.AuthHubKey());
    }
}
