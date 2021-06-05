using AuthHub.BLL.Oranizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Tokens;
using AuthHub.BLL.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<ITokenGeneratoryFactory, TokenServiceFactory>();
            return services;
        }
    }
}