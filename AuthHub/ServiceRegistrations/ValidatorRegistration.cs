using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using AuthHub.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuthHub.ServiceRegistrations
{

    public static class ValidatorRegistrations
    {
        public static IServiceCollection AddAuthHubValidatorFactory(this IServiceCollection services)
        {
            services.AddTransient<IValidatorFactory, ValidatorFactory>();
            return services;
        }
    }

    public interface IValidatorFactory
    {
        void ValidateAndThrow<T>(T request, int version = 1);
    }

    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IOrganizationService _organizationService;
        private readonly IUserLoader _userLoader;

        public ValidatorFactory(
            IOrganizationService organizationService,
            IUserLoader userLoader
            )
        {
            _organizationService = organizationService;
            _userLoader = userLoader;
        }

        public void ValidateAndThrow<T>(T request, int version = 1)
        {
            var validator = GetValidator<T>();
            if (validator == null)
                throw new Exception($"No validator registered for type {typeof(T)}");
            validator.ValidateAndThrow<T>(request);
        }

        private IValidator<T> GetValidator<T>(int version = 1)
        {
            switch ((typeof(T), version))
            {
                case (Type t, int v) when t == typeof(CreateUserRequest) && v == 1:
                    return (IValidator<T>)new CreateUserRequestValidator(_userLoader);
                case (Type t, int v) when t == typeof(CreateOrganizationRequest) && v == 1:
                    return (IValidator<T>)new CreateOrganizationRequestValidator(_organizationService);
                case (Type t, int v) when t == typeof(AuthSettings) && v == 1:
                    return (IValidator<T>)new OrganizationSettingsValidator();
                case (Type t, int v) when t == typeof(PasswordRequest) && v == 1:
                    return (IValidator<T>)new PasswordRequestValidator();
                case (Type t, int v) when t == typeof(Organization) && v == 1:
                    return (IValidator<T>)new OrganizationValidator(_organizationService);
                default:
                    throw new Exception($"No validator registered for type {typeof(T)}");
            }
        }
    }
}