using System.Security.Claims;
using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.BLL.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Enums;
using AuthHub.Models.Passwords;
using Common.Interfaces.Helpers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection AddOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationConsistency, ApplicationConsistency>();
            services.AddTransient((services) =>
            {
                return new TokenServiceFactory((a) =>
                {
                    return a switch
                    {
                        AuthSchemeEnum.JWT => new JWTTokenService(
                                                        services.GetService<IPasswordLoader>(),
                                                        services.GetService<IConfiguration>(),
                                                        services.GetService<IApplicationConsistency>(),
                                                        services.GetService<IMapper<ClaimsEntity, Claim>>()
                                                    ),
                        _ => new JWTTokenService(
                            services.GetService<IPasswordLoader>(),
                            services.GetService<IConfiguration>(),
                            services.GetService<IApplicationConsistency>(),
                            services.GetService<IMapper<ClaimsEntity, Claim>>()
                        )
                    };
                });
            });
            services.AddTransient((services) =>
            {
                return new TokenGeneratorFactory((a) =>
                {
                    return a switch
                    {
                        AuthSchemeEnum.JWT => new JWTTokenGenerator(
                            services.GetService<IOrganizationLoader>(),
                            services.GetService<IApplicationConsistency>()
                        ),
                        _ => new JWTTokenGenerator(
                            services.GetService<IOrganizationLoader>(),
                            services.GetService<IApplicationConsistency>()
                        ),
                    };
                });
            });
            return services;
        }
    }
}
