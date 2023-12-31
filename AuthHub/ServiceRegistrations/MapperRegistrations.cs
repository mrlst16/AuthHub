using AuthHub.Api.FormatMappers;
using AuthHub.Api.Responses;
using AuthHub.BLL.Common.Mappers;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.Api.ServiceRegistrations
{
    public static class MapperRegistrations
    {
        public static IServiceCollection AddFormatMappers(this IServiceCollection services)
        =>
            services
                .AddTransient<IMapper<User, UserIdResponse>, UserIdResponseMapper>()
                .AddTransient<IMapper<PasswordResetToken, RequestPasswordResetTokenResponse>, RequestPasswordResetTokenResponseMapper>()
                .AddTransient<IMapper<User, UserResponse>, UserResponseMapper>();
    }
}