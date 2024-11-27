﻿using AuthHub.BLL.Common.Emails;
using AuthHub.BLL.Common.Providers;
using AuthHub.DAL.EntityFramework;
using AuthHub.Interfaces.Emails;
using AuthHub.Jobs.Jobs.Billing;
using AuthHub.Models.Options;
using Common.Interfaces.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
HostApplicationBuilder app = new HostApplicationBuilder();
app.Configuration
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{env}.json", true);

app.Services.AddDbContext<AuthHubContext>(o =>
    {
        var connectionString = app.Configuration.GetConnectionString("authhub");
        o.UseSqlServer(connectionString);
    })
    .AddTransient<IPaypalClient, PaypalClient>()
    .AddTransient<IEmailService, EmailService>()
    .AddTransient<IBillingEmailService, BillingEmailService>()
    .AddTransient<BillingJob>()
    .Configure<EmailServiceOptions>(app.Configuration.GetSection("AppSettings:Email"));

//If in debug mode, use the mock capabilities of the date provider
#if DEBUG
app.Services.AddTransient<IDateProvider>(provider => new DateProvider(DateTime.Parse("11/04/2024"), DateTime.Now));
#else
app.Services.AddTransient<IDateProvider, DateProvider>();
#endif


Console.WriteLine("Starting...");

try
{
    var host = app.Build();
    var job = (BillingJob)host.Services.GetService(typeof(BillingJob));
    await job.RunAsync();
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