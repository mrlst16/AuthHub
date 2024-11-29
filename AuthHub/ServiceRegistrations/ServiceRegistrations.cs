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
using AuthHub.Models.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using AuthHub.BLL.ApiKeys;
using AuthHub.BLL.AuthSetting;
using AuthHub.BLL.Billing;
using AuthHub.BLL.Claims;
using AuthHub.BLL.Organizations;
using AuthHub.DAL.EntityFramework.AuthSetting;
using AuthHub.Interfaces.APIKeys;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Billing;
using AuthHub.Interfaces.Claims;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Claims;

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
                .AddTransient<IClaimsService, ClaimsService>()
                .AddTransient<IOrganizationService, OrganizationService>()
                .AddTransient<IAPIKeyService, ApiKeyService>()
                .AddTransient<IAuthSettingsService, AuthSettingsService>()
                .AddTransient<IPaypalService, PaypalService>()
                .AddTransient((services) =>
                {
                    return new Func<AuthSchemeEnum, ITokenService>((a) =>
                    {
                        return a switch
                        {
                            AuthSchemeEnum.JWT => new JWTTokenService(
                                services.GetService<IUserLoader>(),
                                services.GetService<IUserContext>(),
                                services.GetService<IConfiguration>(),
                                services.GetService<IApplicationConsistency>(),
                                services.GetService<IDateProvider>(),
                                services.GetService<IMapper<ClaimsEntity, Claim>>(),
                                services.GetService<ITokenContext>(),
                                services.GetService<IVerificationCodeLoader>(),
                                services.GetService<IAuthSettingsContext>()
                                ),
                            _ => null
                        };
                    });
                }); ;
            return services;
        }
    }
}
