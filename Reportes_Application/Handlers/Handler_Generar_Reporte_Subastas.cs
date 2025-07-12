using MediatR;
using Reportes_Application.Commands;
using Reportes_Domain.Exceptions;
using Reportes_Infrastructure.Interfaces;


namespace Reportes_Application.Handlers;

public class Handler_Generar_Reporte_Subastas : IRequestHandler<Command_Generar_Reporte_Subastas, byte[]>
{
    private readonly ISubasta_Servicio _subastaServicio;
    private readonly IPdf_Reporte_Generador _pdf_Generador;
    private readonly IExcel_Reporte_Generador _excel_Generador;

    public Handler_Generar_Reporte_Subastas(ISubasta_Servicio subastaServicio, IPdf_Reporte_Generador pdf_Generador, IExcel_Reporte_Generador excel_Generador)
    {
        _subastaServicio = subastaServicio;
        _pdf_Generador = pdf_Generador;
        _excel_Generador = excel_Generador;
    }

    public async Task<byte[]> Handle(Command_Generar_Reporte_Subastas request, CancellationToken cancellationToken)
    {
        var subastas = await _subastaServicio.Obtener_Subastas_Reporte_Async(request.Filtro);

        return request.Formato switch
        {
            "pdf" => _pdf_Generador.Generar_Reporte_Subastas(subastas),
            "excel" => _excel_Generador.Generar_Reporte_Subastas(subastas),
            _ => throw new Formato_No_Soportado_Exception($"Formato {request.Formato} no soportado")
        };
    }
}