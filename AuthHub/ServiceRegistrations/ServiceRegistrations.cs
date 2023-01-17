using AuthHub.BLL.Common.Emails;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Tokens;
using AuthHub.BLL.Users;
using AuthHub.BLL.Verification;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddAuthHubServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>()
                .AddTransient<IClaimsKeyService, ClaimsKeyService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAuthHubEmailService, AuthHubEmailService>()
                .AddTransient<IVerificationCodeService, VerificationCodeService>()
                .AddTransient<IPasswordResetService, PasswordResetService>()
                .AddTransient((services) =>
                {
                    return new Func<AuthSchemeEnum, ITokenService>((a) =>
                    {
                        return a switch
                        {
                            AuthSchemeEnum.JWT => new JWTTokenService(
                                services.GetService<IUserLoader>(),
                                services.GetService<IConfiguration>(),
                                services.GetService<IApplicationConsistency>(),
                                services.GetService<IDateProvider>(),
                                services.GetService<IMapper<ClaimsEntity, Claim>>(),
                                services.GetService<ITokenLoader>()
                            ),
                            _ => null
                        };
                    });
                }); ;
            return services;
        }
    }
}
