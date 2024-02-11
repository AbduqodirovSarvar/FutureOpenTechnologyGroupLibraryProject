using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Mapings;
using Library.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class DepencyInjection
    {
        public static void ApplicationLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });

            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IEmailService, EmailService>();

            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingconfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
