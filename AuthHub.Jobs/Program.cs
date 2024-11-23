using AuthHub.Jobs.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AuthHub.Jobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            HostApplicationBuilder app = new HostApplicationBuilder();
            app.Configuration.AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{env}.json", true);

            Console.WriteLine("Starting...");
            try
            {
                GlobalConfiguration.Configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(app.Configuration.GetConnectionString("hangfire"));

                RecurringJobOptions options = new RecurringJobOptions()
                {
                    MisfireHandling = MisfireHandlingMode.Relaxed,
                };

                RecurringJob
                    .AddOrUpdate("billing", () => TestJob.Run(),
                        "*/1 * * * * *"
                        );

                using (var server = new BackgroundJobServer())
                {
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
