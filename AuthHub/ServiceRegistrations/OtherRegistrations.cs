using AuthHub.BLL.Common.Helpers;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection RegisterOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationHelper, ApplicationHelper>();
            return services;
        }
    }
}
