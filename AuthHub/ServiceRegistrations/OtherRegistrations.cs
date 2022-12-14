﻿using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.BLL.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Enums;
using AuthHub.Models.Passwords;
using Common.Interfaces.Helpers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

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
