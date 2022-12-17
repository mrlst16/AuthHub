using AuthHub.Api.Validators;
using AuthHub.Models.Requests;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class ValidatorRegistrations
    {
        public static IServiceCollection AddAuthHubValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            return services;
        }
    }
}
