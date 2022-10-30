using AuthHub.BLL.Organizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddAuthHubServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClaimsKeyService, ClaimsKeyService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IPasswordService, PasswordService>();
            return services;
        }
    }
}