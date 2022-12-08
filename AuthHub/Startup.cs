using AuthHub.Api.Middleware;
using AuthHub.Api.ServiceRegistrations;
using AuthHub.BLL.Auth;
using AuthHub.BLL.Common.Tokens;
using AuthHub.DAL.EntityFramework;
using AuthHub.DAL.EntityFramework.Generic;
using AuthHub.Interfaces.Auth;
using AuthHub.Models.Options;
using Common.AspDotNet.Extensions;
using Common.AspDotNet.Handlers;
using Common.Interfaces.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AuthHub.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthHubContext>(o =>
            {
                var connectionString = Configuration.GetConnectionString("authhub");
                o.UseSqlServer(connectionString);
            })
            .AddTransient<IAuthenticationService, AuthenticationService>()
            .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
            .AddTransient<JWTTokenGenerator, JWTTokenGenerator>()
            .AddTransient(typeof(ISRDRepository<,>), typeof(AuthHubRepository<,>))
            .AddAuthHubServices()
            .AddAuthHubLoaders()
            .AddAuthHubValidators()
            .AddAuthHubContexts()
            .AddAuthHubOthers()
            .AddCommon()
            .Configure<EmailServiceOptions>(Configuration.GetSection("AppSettings:Email"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = APICredentialsAuthenticationHandler.Scheme;
            })
            .AddScheme<APICredentialsOptions, APICredentialsAuthenticationHandler>(
                APICredentialsAuthenticationHandler.Scheme,
                options => { });

            services.AddControllers();
            services.AddSwaggerGen(c =>
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

            app.UseHttpsRedirection();

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