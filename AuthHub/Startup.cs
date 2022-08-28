using AuthHub.BLL.Common.Extensions;
using AuthHub.DAL.EntityFramework.Organizations;
using AuthHub.DAL.EntityFramework.Passwords;
using AuthHub.DAL.EntityFramework.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Middleware;
using AuthHub.ServiceRegistrations;
using CommonCore.Api.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AuthHub
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
            services
                .AddTransient<IUserContext, UserContext>()
                .AddTransient<IClaimsKeyContext, ClaimsKeyContext>()
                .AddTransient<IPasswordContext, PasswordsContext>()
                .AddTransient<IOrganizationContext, OrganizationContext>()      
                .RegisterLoaders()
                .RegisterServices()
                .RegisterValidatorFactory()
                .RegisterOthers();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthHub", Version = "v1" });
            });

            services.AddAuthHubJWTAuthentication(Configuration.AuthHubKey(), Configuration.AuthHubIssuer());

            services.AddAuthorization(x =>
            {
                x.AddPolicy(JwtBearerDefaults.AuthenticationScheme, y =>
                {
                    y.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    y.AddRequirements(new JWTAuthorizationRequirement());
                });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}