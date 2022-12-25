using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AuthHub.SDK.Interfaces;

namespace AuthHub.SDK
{
    public static class IServiceCollectionExtensions
    {
        private const string JWTAuthSettingsKey = "AuthHub:JWTAuthSettings";

        public static IServiceCollection AddAuthHubJWTAuthentication(
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
           }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            return services;
        }

        public static IServiceCollection AddAuthHubJWTAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var section = configuration.GetSection("AuthHub:JWT");
            if (section == null) return services;

            return services.AddAuthHubJWTAuthentication(
                section.GetValue<string>("Issuer"),
                section.GetValue<string>("Audience"),
                section.GetValue<string>("Key")
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
    }
}
