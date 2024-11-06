using AuthHub.Models.Entities.Claims;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static int AuthHubOrganizationId(this IConfiguration configuration)
            => configuration.GetValue<int>("AppSettings:AuthHubOrganiztionID");
        public static string AuthHubIssuer(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubIssuer");
        public static string AuthHubKey(this IConfiguration configuration)
            => configuration.GetValue<string>("AppSettings:AuthHubKey");
        public static int AuthHubSettingsId(this IConfiguration configuration)
            => configuration.GetValue<int>("AppSettings:AuthHubSettingsId");

        public static ClaimsKey GetClaimsKey(this IConfiguration configuration, string name)
            => new ClaimsKey()
            {
                Name = name,
                Id = configuration.GetValue<int>($"AppSettings:AuthHubClaimsKeys:{name}"),
            };

        public static ClaimsEntity CreateClaimsEntity(this IConfiguration configuration, string name, string value, int? id = null)
        {
            var claimsKey = configuration.GetClaimsKey(name);
            return new ClaimsEntity()
            {
                Key = name,
                Value = value,
                ClaimsKeyId = claimsKey.Id,
                Id = id ?? -1
            };
        }

        /// <summary>
        /// Returns the auth hub organization info.  In this case, the organization is the application itself acting as the
        /// organization
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>AuthSettingsId, Issuer, Key</returns>
        public static (int, string, string) AuthHubAuthInfo(this IConfiguration configuration)
            => (configuration.AuthHubOrganizationId(), configuration.AuthHubIssuer(), configuration.AuthHubKey());
    }
}
