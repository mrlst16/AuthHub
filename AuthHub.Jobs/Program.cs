using AuthHub.BLL.Common.Emails;
using AuthHub.BLL.Common.Providers;
using AuthHub.DAL.EntityFramework;
using AuthHub.Interfaces.Emails;
using AuthHub.Jobs;
using AuthHub.Jobs.Jobs.Billing;
using AuthHub.Models.Options;
using Common.Interfaces.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Quartz.Simpl;
using Quartz.Spi;
using BillingJob = AuthHub.Jobs.Jobs.Billing.BillingJob;

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
    .Configure<EmailServiceOptions>(app.Configuration.GetSection("AppSettings:Email"))
    .AddQuartz(quartz =>
    {
        //quartz.ScheduleJob<ConsoleJob>(trigger =>
        //{
        //    trigger.WithSimpleSchedule(s =>
        //    {
        //        s.WithIntervalInSeconds(5);
        //    })
        //    .StartNow();
        //}, job =>
        //{
        //});
    })
    .AddQuartzHostedService(q =>
    {
        q.WaitForJobsToComplete = true;
    });

//If in debug mode, use the mock capabilities of the date provider
#if DEBUG
app.Services.AddTransient<IDateProvider>(provider => new DateProvider(DateTime.Parse("11/04/2024"), DateTime.Now));
#else
app.Services.AddTransient<IDateProvider, DateProvider>();
#endif

IHost host = app.Build();

try
{
    Console.WriteLine("Starting...");
    LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
    IScheduler scheduler = await SchedulerBuilder.Create()
        .BuildScheduler();
    scheduler.JobFactory = new ServiceProviderJobFactory(host.Services);

    //IScheduler scheduler = await factory.GetScheduler();
    await scheduler.Start();

    IJobDetail bjDetail = JobBuilder.Create<BillingJob>().Build();
    ITrigger bjTrigger = TriggerBuilder.Create()
        .WithSimpleSchedule(s =>
        {
            s.WithInterval(TimeSpan.FromDays(1))
                .RepeatForever();
        })
        .StartNow()
        .Build();

    await scheduler.ScheduleJob(bjDetail, bjTrigger);

    while (true)
    {
        await Task.Delay(TimeSpan.FromDays(1));
    }
}
catch (Exception e)
{
    
}

public class ServiceProviderJobFactory:SimpleJobFactory
{
    private readonly IServiceProvider _serviceProvider;
    public ServiceProviderJobFactory(
        IServiceProvider serviceProvider
        )
    {
        _serviceProvider = serviceProvider;
    }

    public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        return (IJob) _serviceProvider.GetService(bundle.JobDetail.JobType);
    }
}