using CommonCore.Interfaces.Repository;
using CommonCore2.Repository.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthHub.ServiceRegistrations
{
    public static class ContextRegistration
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICrudRepositoryFactory>(x =>
                new MongoDbCrudRepositoryFactory(
                    configuration.GetConnectionString("mongodb_connection")));
            return services;
        }
    }
}
