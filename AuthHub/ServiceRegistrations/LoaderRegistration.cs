﻿using AuthHub.BLL.AuthSetting;
using AuthHub.BLL.Claims;
using AuthHub.BLL.Common.Tokens;
using AuthHub.BLL.Organizations;
using AuthHub.BLL.Passwords;
using AuthHub.BLL.Users;
using AuthHub.BLL.Verification;
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
    public static class LoaderRegistration
    {
        public static IServiceCollection AddAuthHubLoaders(this IServiceCollection services)
        {
            services.AddTransient<IUserLoader, UserLoader>()
                .AddTransient<IClaimsKeyLoader, ClaimsKeyLoader>()
                .AddTransient<IOrganizationLoader, OrganizationLoader>()
                .AddTransient<IAuthSettingsLoader, AuthSettingsLoader>()
                .AddTransient<ITokenLoader, TokenLoader>()
                .AddTransient<IClaimsLoader, ClaimsLoader>()
                .AddTransient<IVerificationCodeLoader, VerificationCodeLoader>();
            return services;
        }
    }
}
