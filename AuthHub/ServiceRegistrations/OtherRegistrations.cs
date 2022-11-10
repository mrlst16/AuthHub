using AuthHub.BLL.Common.Helpers;
using Common.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection AddOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationConsistency, ApplicationConsistency>();
            return services;
        }
    }
}
