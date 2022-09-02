
using Microsoft.Extensions.Configuration;

namespace AuthHub.SDK
{
    public static class ConfigurationExtensions
    {
        public static AuthHubOptions GetAuthHubOptions(this IConfiguration configuration)
        {
            AuthHubOptions result = new();
            configuration.GetSection(AuthHubOptions.Path).Bind(result);
            return result;
        }
    }
}
