using AuthHub.Api.ServiceRegistrations;
using Common.Interfaces.Repository;
using Common.Repository;

namespace AuthHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder
                .Services
                .AddTransient(typeof(ISRDRepository<,>), typeof(EntityFrameworkSRDRepository<,>))
                .AddAuthHubLoaders()
                .AddAuthHubServices()
                .AddAuthHubValidatorFactory()
                .AddOthers()
                .AddControllers();

            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(p =>
                    p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}