using AuthHub.BLL.Oranizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class LoaderRegistration
    {
        public static IServiceCollection RegisterLoaders(this IServiceCollection services)
        {
            services.AddTransient<IUserLoader, UserLoader>();
            services.AddTransient<IPasswordLoader, PasswordLoader>();
            services.AddTransient<IOrganizationLoader, OrganizationLoader>();
            services.AddTransient<IAuthHubOrganizationLoader, AuthHubOrganizationLoader>();
            return services;
        }
    }
}