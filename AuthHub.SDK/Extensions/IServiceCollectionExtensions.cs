using AuthHub.SDK.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AuthHub.SDK.Connectors;
using AuthHub.SDK.Handlers;

namespace AuthHub.SDK.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthHubAuthenticationAsDefault(
            this IServiceCollection services,
            string issuer,
            string audience,
            string key
            )
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer = issuer,
                     ValidAudience = audience,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = false,
                     ValidateIssuerSigningKey = true
                 };
             });
            return services;
        }

        public static IServiceCollection AddAuthHubAuthenticationAsDefault(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            string issuer = configuration.GetValue<string>("AuthHub:Issuer");
            string audience = configuration.GetValue<string>("AuthHub:Audience");
            string key = configuration.GetValue<string>("AuthHub:Key");

            return services.AddAuthHubAuthenticationAsDefault(
                issuer,
                audience,
                key
            );
        }

        public static IServiceCollection AddAuthHubConnectors(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient<IUserConnector>(x => new UserConnector(configuration));
            return services;
        }

        public static IServiceCollection AddAuthHubAuthentication(
            this IServiceCollection services,
            string issuer,
            string audience,
            string key
            )
        {
            services.AddAuthentication().AddScheme<AuthHubAuthHandlerOptions, AuthHubAuthHandler>(
                AuthHubAuthHandler.Scheme,
                options =>
                {
                    options.Issuer = issuer;
                    options.Audience = audience;
                    options.Key = key;
                }
            );
            return services;
        }

        public static IServiceCollection AddAuthHubAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            string issuer = configuration.GetValue<string>("AuthHub:Issuer");
            string audience = configuration.GetValue<string>("AuthHub:Audience");
            string key = configuration.GetValue<string>("AuthHub:Key");
            return services.AddAuthHubAuthentication(issuer, audience, key);
        }
    }
}