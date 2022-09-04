using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuthHub.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection AddOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationConsistency, ApplicationConsistency>();
            services.AddTransient<Func<AuthSchemeEnum, ITokenGenerator>>((services) =>
            {
                return new Func<AuthSchemeEnum, ITokenGenerator>((a) =>
                {
                    switch (a)
                    {
                        case AuthSchemeEnum.JWT:
                            return new JWTTokenGenerator(
                                services.GetService<IOrganizationLoader>(),
                                services.GetService<IPasswordLoader>(),
                                services.GetService<IUserLoader>(),
                                services.GetService<IConfiguration>(),
                                services.GetService<IApplicationConsistency>(),
                                services.GetService<IDateProvider>()
                            );
                        default:
                            return new JWTTokenGenerator(
                                services.GetService<IOrganizationLoader>(),
                                services.GetService<IPasswordLoader>(),
                                services.GetService<IUserLoader>(),
                                services.GetService<IConfiguration>(),
                                services.GetService<IApplicationConsistency>(),
                                services.GetService<IDateProvider>()
                            );
                    }
                });
            });
            return services;
        }
    }
}
