using AuthHub.BLL.Auth;
using AuthHub.BLL.Common.Extensions;
using AuthHub.BLL.Common.Tokens;
using AuthHub.DAL.EntityFramework;
using AuthHub.DAL.EntityFramework.Generic;
using AuthHub.DAL.EntityFramework.Organizations;
using AuthHub.DAL.EntityFramework.Passwords;
using AuthHub.DAL.EntityFramework.Users;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Middleware;
using AuthHub.Models.Users;
using AuthHub.ServiceRegistrations;
using AuthHub.Validators;
using Common.AspDotNet;
using Common.Interfaces.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AuthHub
{
    public class Startup
    {

        private DbContextOptionsBuilder<AuthHubContext> AuthHubContextOptionsBuilder
            => new DbContextOptionsBuilder<AuthHubContext>()
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
                .EnableDetailedErrors()
                .UseNpgsql(Configuration.GetConnectionString("dopgsql"));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddDbContext<AuthHubContext>(o => o = AuthHubContextOptionsBuilder)
                .AddSingleton(x => new AuthHubContext(AuthHubContextOptionsBuilder.Options))
                .AddTransient<IAuthHubAuthenticationService, AuthenticationService>()
                .AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>()
                .AddTransient<IAuthorizationHandler, OrganizationAuthHandler>()
                .AddTransient<IUserContext, UserContext>()
                .AddTransient<IClaimsKeyContext, ClaimsKeyContext>()
                .AddTransient<IPasswordContext, PasswordsContext>()
                .AddTransient<IOrganizationContext, OrganizationContext>()
                .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddTransient<JWTTokenGenerator, JWTTokenGenerator>()
                .AddTransient(typeof(ISRDRepository<,>), typeof(AuthHubRepository<,>))
                .AddAuthHubLoaders()
                .AddAuthHubServices()
                .AddAuthHubValidatorFactory()
                .AddOthers()
                .AddCommon();

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
                    y.AddRequirements(new OrganizationAuthRequirement());
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}