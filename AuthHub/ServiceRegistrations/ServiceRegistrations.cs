using AuthHub.BLL.Common.Emails;
using AuthHub.BLL.Organizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Users;
using AuthHub.BLL.Verification;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddAuthHubServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>()
                .AddTransient<IClaimsKeyService, ClaimsKeyService>()
                .AddTransient<IOrganizationService, OrganizationService>()
                .AddTransient<IPasswordService, PasswordService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAuthHubEmailService, AuthHubEmailService>()
                .AddTransient<IVerificationCodeService, VerificationCodeService>();
            return services;
        }
    }
}