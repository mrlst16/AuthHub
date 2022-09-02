using AuthHub.BLL.Common.Emails;
using AuthHub.BLL.Common.Organizations;
using AuthHub.BLL.Organizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Users;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class LoaderRegistration
    {
        public static IServiceCollection AddAuthHubLoaders(this IServiceCollection services)
        {
            services.AddTransient<IUserLoader, UserLoader>();
            services.AddTransient<IClaimsKeyLoader, ClaimsKeyLoader>();
            services.AddTransient<IPasswordLoader, PasswordLoader>();
            services.AddTransient<IOrganizationLoader, OrganizationLoader>();
            services.AddTransient<IAuthHubOrganizationLoader, AuthHubOrganizationLoader>();
            services.AddTransient<IAuthHubEmailLoader, AuthHubEmailLoader>();
            return services;
        }
    }
}
