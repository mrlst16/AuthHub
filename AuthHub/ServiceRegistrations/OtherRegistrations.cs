using AuthHub.BLL.Common.Helpers;
using AuthHub.DAL.Sql.Mappers;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class OtherRegistrations
    {
        public static IServiceCollection RegisterOthers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationHelper, ApplicationHelper>();
            services.AddTransient<IUdtMapper, UdtMapper>();
            services.AddTransient<IDataSetMapper, DataSetMapper>();
            return services;
        }
    }
}
