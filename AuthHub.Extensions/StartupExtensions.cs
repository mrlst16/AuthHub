using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthHub.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection UseAuthHubJWTAuthorization(IServiceCollection services, string key, string issuer)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateLifetime = true,
                    NameClaimType = ClaimTypes.Name,
                    TokenReader = (token, parameters) =>
                    {
                        var result = new JwtSecurityToken();
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        result = handler.ReadJwtToken(token);
                        return result;
                    }
                };
            });
            return services;
        }
    }
}
