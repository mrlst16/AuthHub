using AuthHub.DAL.EntityFramework.AuthSetting;
using AuthHub.DAL.EntityFramework.Organizations;
using AuthHub.DAL.EntityFramework.Passwords;
using AuthHub.DAL.EntityFramework.Users;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class ContextRegistrations
    {
        public static IServiceCollection AddAuthHubContexts(this IServiceCollection services)
        {
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<IClaimsKeyContext, ClaimsKeyContext>();
            services.AddTransient<IPasswordContext, PasswordsContext>();
            services.AddTransient<IOrganizationContext, OrganizationContext>();
            services.AddTransient<IAuthSettingsContext, AuthSettingsContext>();
            return services;
        }
    }
}
