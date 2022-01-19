using AuthHub.SDK;
using AuthHub.WebUI.Connectors;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthHub.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44351")
            });
            builder.Services.AddTransient<IApiConnector, ApiConnector>();
            builder.Services.AddTransient<IOrganizationConnector, OrganizationConnector>();
            builder.Services.AddTransient<ITokenConnector, JWTTokenConnector>();
            builder.Services.AddTransient<ILocalStorageProvider, LocalStorageProvider>();
            await builder.Build().RunAsync();
        }
    }
}
