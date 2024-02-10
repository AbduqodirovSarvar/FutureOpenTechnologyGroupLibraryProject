using Library.Application;
using Library.Application.Services;
using Library.Infrastructure;
using Library.Presentation.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    });
        }
    }
}
