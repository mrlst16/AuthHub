using AuthHub.Models.Passwords;
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
        public static Guid AuthHubSettingsId(this IConfiguration configuration)
            => configuration.GetValue<Guid>("AppSettings:AuthHubSettingsId");

        public static ClaimsKey GetClaimsKey(this IConfiguration configuration, string name)
            => new ClaimsKey()
            {
                Name = name,
                Id = configuration.GetValue<Guid>($"AppSettings:AuthHubClaimsKeys:{name}"),
                AuthSettingsId = configuration.AuthHubSettingsId()
            };

        public static ClaimsEntity CreateClaimsEntity(this IConfiguration configuration, string name, string value, Guid? id = null)
        {
            var claimsKey = configuration.GetClaimsKey(name);
            return new ClaimsEntity()
            {
                Key = name,
                Value = value,
                ClaimsKeyId = claimsKey.Id,
                Id = id ?? Guid.Empty
            };
        }

        public static (Guid, string, string) AuthHubAuthInfo(this IConfiguration configuration)
            => (configuration.AuthHubOrganizationId(), configuration.AuthHubIssuer(), configuration.AuthHubKey());
    }
}
