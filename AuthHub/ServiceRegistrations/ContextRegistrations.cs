using AuthHub.DAL.EntityFramework.AuthSetting;
using AuthHub.DAL.EntityFramework.Claims;
using AuthHub.DAL.EntityFramework.Organizations;
using AuthHub.DAL.EntityFramework.Passwords;
using AuthHub.DAL.EntityFramework.Tokens;
using AuthHub.DAL.EntityFramework.Users;
using AuthHub.DAL.EntityFramework.Verification;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Claims;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class ContextRegistrations
    {
        public static IServiceCollection AddAuthHubContexts(this IServiceCollection services)
        {
            services.AddTransient<IUserContext, UserContext>()
                .AddTransient<IClaimsKeyContext, ClaimsKeyContext>()
                .AddTransient<IPasswordContext, PasswordsContext>()
                .AddTransient<IOrganizationContext, OrganizationContext>()
                .AddTransient<IAuthSettingsContext, AuthSettingsContext>()
                .AddTransient<ITokenContext, TokenContext>()
                .AddTransient<IClaimsContext, ClaimsContext>()
                .AddTransient<IVerificationCodeContext, VerificationCodeContext>();

            return services;
        }
    }
}
