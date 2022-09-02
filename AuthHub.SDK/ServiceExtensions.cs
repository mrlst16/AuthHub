using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.SDK
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAuthHubSDKForWebClient(this IServiceCollection services)
        {
            services.AddTransient<IApiConnector, WebApiConnector>()
                .AddTransient<IUserConnector, UserConnector>();
            return services;
        }
    }
}
