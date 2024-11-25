using AuthHub.Jobs.Jobs;
using AuthHub.Jobs.Jobs.Billing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
HostApplicationBuilder app = new HostApplicationBuilder();
app.Configuration
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{env}.json", true);
            
Console.WriteLine("Starting...");

try
{

    HttpClient http = new HttpClient();
    http.BaseAddress = new Uri("https://www.google.com");
    var response = await http.GetAsync("");

    PaypalClient client = new PaypalClient(app.Configuration);
    client.GetAuthToken();
}
catch (Exception e)
{
                

}
//try
//{
//    while (true)
//    {
//        //BillingJob billingJob = new BillingJob(
//        //)
//        Thread.Sleep(TimeSpan.FromDays(1));
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//}