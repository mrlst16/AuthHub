using AuthHub.Api.Helpers;
using AuthHub.SDK.Extensions;
using System.Text.Json.Serialization;

namespace DotnetTestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.PropertyNamingPolicy = new CapitalizedNamingPolicy();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder
                .Services
                .AddAuthHubAuthentication(builder.Configuration)
                .AddAuthHubConnectors(builder.Configuration);

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
