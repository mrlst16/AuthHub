using AuthHub.Api.Middleware;
using AuthHub.Api.ServiceRegistrations;
using AuthHub.BLL.Common.Hashing;
using AuthHub.BLL.Common.Tokens;
using AuthHub.BLL.Passwords;
using AuthHub.DAL.EntityFramework;
using AuthHub.Interfaces.Hashing;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Options;
using Common.Interfaces.Providers;
using Common.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using AuthHub.Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthHub.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; protected set; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false)
                .Build();

            Console.WriteLine($"Connection String: {Configuration.GetConnectionString("authhub")}");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthHubContext>(o =>
                {
                    var connectionString = Configuration.GetConnectionString("authhub");
                    o.UseSqlServer(connectionString);
                })
                .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddTransient<JWTTokenGenerator, JWTTokenGenerator>()
                .AddTransient<ICredentialsEvaluator, CredentialsEvaluator>()
                .AddTransient<IPasswordEvaluator, PasswordEvaluator>()
                .AddTransient<IHasher, Hasher>()
                .AddAuthHubServices()
                .AddAuthHubLoaders()
                .AddAuthHubValidators()
                .AddAuthHubContexts()
                .AddAuthHubOthers()
                .AddFormatMappers()
                .AddTransient<IDateProvider, DateProvider>()
                .Configure<EmailServiceOptions>(Configuration.GetSection("AppSettings:Email"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = APICredentialsAuthenticationHandler.Scheme;
            })
            .AddScheme<APICredentialsOptions, APICredentialsAuthenticationHandler>(
                APICredentialsAuthenticationHandler.Scheme,
                options => { })
            .AddScheme<UserCredentialsOptions, UserCredentialsAuthenticationHandler>(
                UserCredentialsAuthenticationHandler.Scheme,
                options => { })
            .AddScheme<APIAndUserCredentialsOptions, APIAndUserCredentialsAuthenticationHandler>(
                APIAndUserCredentialsAuthenticationHandler.Scheme,
                options => { })
            .AddScheme<ApiAndLoggedInUserAuthenticationHandlerOptions, ApiAndLoggedInUserAuthenticationHandler>(
                ApiAndLoggedInUserAuthenticationHandler.Scheme,
                options => { });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.PropertyNamingPolicy = new CapitalizedNamingPolicy();
            });
            services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthHub", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthHub v1"));
            }

            app.UseCors(p =>
            {
                p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.Use(async (context, next) =>
            {
                ErrorHandlingMiddleware errorHandler = new ErrorHandlingMiddleware();
                await errorHandler.Handle(context, next);
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}