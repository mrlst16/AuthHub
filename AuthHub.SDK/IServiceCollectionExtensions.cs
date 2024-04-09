using AuthHub.SDK.Interfaces;
using AuthHub.SDK.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthHub.SDK
{
    public static class IServiceCollectionExtensions
    {
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

        public static IServiceCollection AddAuthHubConnectors(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var section = configuration.GetSection("AuthHub");
            services.Configure<AuthHubConnectorOptions>(section)
                .AddTransient<IUserConnector, UserConnector>()
                .AddTransient<ITokenConnector, TokenConnector>()
                .AddTransient<IVerificationConnector, VerificationConnector>()
                .AddTransient<IClaimsConnector, ClaimsConnector>();
            return services;
        }
    }
}
