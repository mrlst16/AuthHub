using AuthHub.DAL.Sql;
using AuthHub.DAL.Sql.Organizations;
using AuthHub.DAL.Sql.Passwords;
using AuthHub.DAL.Sql.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using CommonCore.Interfaces.Repository;
using CommonCore2.Repository.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuthHub.ServiceRegistrations
{
    public static class ContextRegistration
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnectionString = configuration.GetConnectionString("mongodb_connection");
            var sqlConnectionString = configuration.GetConnectionString("local");

            services.AddTransient<Func<int, IConnectionString>>(x =>
                new Func<int, IConnectionString>((i) =>
                {
                    switch (i)
                    {
                        case 1:
                            return new ConnectionString(mongoConnectionString);
                        case 2:
                            return new ConnectionString(sqlConnectionString);
                        default:
                            return new ConnectionString(mongoConnectionString);
                    }
                }));

            services.AddTransient<ICrudRepositoryFactory>(x =>
                new MongoDbCrudRepositoryFactory(mongoConnectionString)
                );

            services.AddTransient<ISqlServerContext, SqlServerContext>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<IPasswordContext, PasswordsContext>();
            services.AddTransient<IOrganizationContext, OrganizationContext>();

            return services;
        }
    }
}
