using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reportes_Domain.DTOs;
using Reportes_Application.Commands;
using Reportes_Domain.Exceptions;

namespace Reportes_Web.Controllers;
[ApiController]
[Route("api/Reportes")]
public class Reportes_Controladora : ControllerBase
{
    private readonly IMediator _mediador;

    public Reportes_Controladora(IMediator mediador)
    {
        _mediador = mediador;
    }

    [HttpPost("subastas")]
    public async Task<IActionResult> Generar_Reporte_Subastas(
        [FromBody] Filtro_Reporte_Dto filtro,
        [FromQuery] string formato)
    {
        try
        {
            var contenido = await _mediador.Send(
                new Command_Generar_Reporte_Subastas(filtro, formato));

            var contenido_Tipo = formato.ToLower() switch
            {
                "pdf" => "application/pdf",
                "excel" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream"
            };

            var nombre_Archivo = $"ReporteSubastas_{DateTime.Now:yyyyMMddHHmmss}.{formato}";
            
            return File(contenido, contenido_Tipo, nombre_Archivo);
        }
        catch (Error_Generar_Reporte error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost("pujas")]
    public async Task<IActionResult> Generar_Reporte_Pujas(
        [FromBody] Filtro_Pujas_Dto filtro,
        [FromQuery] string formato)
    {
        try
        {
            var contenido = await _mediador.Send(
                new Command_Generar_Reporte_Pujas(filtro, formato));

            var contentType = formato.ToLower() switch
            {
                "pdf" => "application/pdf",
                "excel" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream"
            };

            var nombreArchivo = $"ReportePujas_{DateTime.Now:yyyyMMddHHmmss}.{formato}";
            
            return File(contenido, contentType, nombreArchivo);
        }
        catch (Error_Generar_Reporte error)
        {
            return BadRequest(error.Message);
        }
    }
    // 
    [HttpPost("pagos")]
    public async Task<IActionResult> Generar_Reporte_Pagos(
        [FromBody] Filtro_Pagos_Dto filtro,
        [FromQuery] string formato)
    {
        try
        {
            var contenido = await _mediador.Send(
                new Command_Generar_Reporte_Pagos(filtro, formato));

            var contentType = formato.ToLower() switch
            {
                "pdf" => "application/pdf",
                "excel" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream"
            };

            var nombreArchivo = $"ReportePagos_{DateTime.Now:yyyyMMddHHmmss}.{formato}";
            
            return File(contenido, contentType, nombreArchivo);
        }
        catch (Error_Generar_Reporte error)
        {
            return BadRequest(error.Message);
        }
    }
}