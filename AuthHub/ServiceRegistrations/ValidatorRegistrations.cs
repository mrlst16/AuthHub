using AuthHub.Models.Users;
using AuthHub.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
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
