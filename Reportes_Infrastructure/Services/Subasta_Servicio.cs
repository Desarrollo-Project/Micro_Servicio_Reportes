using Reportes_Domain.DTOs;
using Reportes_Infrastructure.Interfaces;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace Reportes_Infrastructure.Services;

public class Subasta_Servicio : ISubasta_Servicio
{
    private readonly HttpClient _http_Cliente;
    private readonly IConfiguration _configuration;

    public Subasta_Servicio(HttpClient http_Cliente, IConfiguration configuration) 
    {
            _http_Cliente = http_Cliente;
            _configuration=configuration;

    }
    public async Task<IEnumerable<Subasta_Reporte_Dto>> Obtener_Subastas_Reporte_Async(Filtro_Reporte_Dto filtro)
    {

        //TODO: Cambiar a la url del microservicio en el appsettings.json
        var Subastas_Url = _configuration["Ms_Directorio:subastas-Url"];
        var response = await _http_Cliente.PostAsJsonAsync($"{Subastas_Url}/api/subastas/reporte", filtro);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Subasta_Reporte_Dto>>()
            ?? Enumerable.Empty<Subasta_Reporte_Dto>();
    }

    public async Task<IEnumerable<Puja_Reporte_Dto>> Obtener_Pujas_Reporte_Async(Filtro_Pujas_Dto filtro)
    {
        //TODO: Cambiar a la url del microservicio en el appsettings.json
        var Pujas_Url = _configuration["Ms_Directorio:pujas-Url"];
        var queryParams = new Dictionary<string, string>();
        
        if (!string.IsNullOrEmpty(filtro.Id_Usuario))
            queryParams.Add("usuarioId", filtro.Id_Usuario);
            
        
        var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        var url = $"{Pujas_Url}/api/pujas/reporte?{queryString}";
        
        var response = await _http_Cliente.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Puja_Reporte_Dto>>()
            ?? Enumerable.Empty<Puja_Reporte_Dto>();
    }

    public async Task<IEnumerable<Pago_Reporte_Dto>> Obtener_Pagos_Reporte_Async(Filtro_Pagos_Dto filtro)
    {
        //TODO: Cambiar a la url del microservicio en el appsettings.json
        var pagosServiceUrl = _configuration["Ms_Directorio:pagos-Url"];
        var queryParams = new Dictionary<string, string>();
        
        if (!string.IsNullOrEmpty(filtro.Usuario_Id))
            queryParams.Add("subastadorId", filtro.Usuario_Id);
        if (!string.IsNullOrEmpty(filtro.Fecha_Inicio))
            queryParams.Add("fechaInicio", filtro.Fecha_Inicio);
        if (!string.IsNullOrEmpty(filtro.Fecha_Fin))
            queryParams.Add("fechaFin", filtro.Fecha_Fin);
        if (!string.IsNullOrEmpty(filtro.Estado))
            queryParams.Add("estado", filtro.Estado);

        var queryString = string.Join("&", queryParams);
        var url = $"{pagosServiceUrl}/api/pagos/reporte?{queryString}";

        var response = await _http_Cliente.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Pago_Reporte_Dto>>()
            ?? Enumerable.Empty<Pago_Reporte_Dto>();
    }
}