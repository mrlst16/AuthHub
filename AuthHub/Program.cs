using System.Threading;
using AuthHub.DAL.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //https://www.twilio.com/blog/containerize-your-aspdotnet-core-application-and-sql-server-with-docker
            using (var scope = host.Services.CreateScope())
            {
                bool tryAgain = true;
                while (tryAgain)
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetRequiredService<AuthHubContext>();
                        context.Database.Migrate();
                        tryAgain = false;
                        Console.WriteLine("Migrations applied");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Thread.Sleep(3000);
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
