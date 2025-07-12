using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reportes_Domain;
using Reportes_Infrastructure;

namespace Reportes_Application
{
    public static class Application_Modulo
    {
        public static IServiceCollection Usar_Aplicacion(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register MediatR services
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            // Configuración de dependencias de infraestructura
            services.Usar_Infraestructura(configuration);

            // Configuración de dependencias de dominio
            services.Usar_Dominio();

            return services;
        }
    }
}