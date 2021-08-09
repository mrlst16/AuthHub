using AuthHub.BLL.Helpers;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
