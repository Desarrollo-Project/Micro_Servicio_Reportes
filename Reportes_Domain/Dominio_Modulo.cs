using Microsoft.Extensions.DependencyInjection;

namespace Reportes_Domain;

public static class Domain_Modulo
{
    public static IServiceCollection Usar_Dominio(this IServiceCollection services)
    {
        // Aqu� puedes registrar tus servicios de dominio, repositorios, etc.
        // Por ejemplo:
        // services.AddScoped<IMiServicioDeDominio, MiServicioDeDominio>();

        return services;
    }
}