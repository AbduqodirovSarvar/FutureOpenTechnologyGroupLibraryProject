using Library.Application;
using Library.Application.Services;
using Library.Infrastructure;
using Library.Infrastructure.DB;
using Library.Presentation.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Library.Presentation
{
    public static class DepencyInjection
    {
        public static void PresentationLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ApplicationLayerServices();
            services.InfrastructureLayerServices(configuration);
            services.AddControllers().AddApplicationPart(typeof(ApiController).Assembly);
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                        //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        options.JsonSerializerOptions.WriteIndented = true;
                    });
            /*services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });*/

        }

        public static void PresentationLayerWebApplicationServices(this WebApplication app)
        {


            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            try
            {
                context.Database.Migrate();
                Console.WriteLine("Migrations applying successfully completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying migrations: {ex.Message}");
            }
        }
    }
}
