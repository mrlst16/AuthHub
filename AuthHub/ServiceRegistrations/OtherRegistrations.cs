using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Enums;
using Common.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection AddAuthHubOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationConsistency, ApplicationConsistency>();

            services.AddTransient((services) =>
            {
                return new Func<AuthSchemeEnum, ITokenGenerator>((a) =>
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
