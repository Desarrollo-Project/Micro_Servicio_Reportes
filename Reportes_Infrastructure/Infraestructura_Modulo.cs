using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reportes_Infrastructure.Interfaces;
using Reportes_Infrastructure.Services;


namespace Reportes_Infrastructure;

public static class Infraestructure_Modulo
{
    public static IServiceCollection Usar_Infraestructura(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Aqu� puedes registrar tus servicios de infraestructura, como bases de datos, servicios externos, etc.
        // Por ejemplo:
        // services.AddScoped<IMiServicioDeInfraestructura, MiServicioDeInfraestructura>();

        // Configuración HTTP Client para servicio de subastas
        services.AddHttpClient<ISubasta_Servicio, Subasta_Servicio>(client =>
        {
            //TODO: Confirmar si es correcto el nombre de la ruta
            client.BaseAddress = new Uri(configuration["Ms_Directorio"]);
        });

        services.AddScoped<IExcel_Reporte_Generador, Excel_Reporte_Generador>();
        services.AddScoped<IPdf_Reporte_Generador, Pdf_Reporte_Generador>();


        return services;
    }
}