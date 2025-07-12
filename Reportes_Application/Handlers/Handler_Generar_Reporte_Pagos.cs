using MediatR;
using Reportes_Application.Commands;
using Reportes_Domain.DTOs;
using Reportes_Infrastructure.Interfaces;
using Reportes_Domain.Exceptions;

namespace Reportes_Application.Handlers;

public class Handler_Generar_Reporte_Pagos : IRequestHandler<Command_Generar_Reporte_Pagos, byte[]>
{
    private readonly ISubasta_Servicio _subasta_Servicio;
    private readonly IPdf_Reporte_Generador _pdf_Reporte_Generador;
    private readonly IExcel_Reporte_Generador _excel_Reporte_Generador;

    public Handler_Generar_Reporte_Pagos(ISubasta_Servicio subasta_Servicio, IPdf_Reporte_Generador pdf_Reporte_Generador, IExcel_Reporte_Generador excel_Reporte_Generador)
    {
        _subasta_Servicio = subasta_Servicio;
        _pdf_Reporte_Generador = pdf_Reporte_Generador;
        _excel_Reporte_Generador = excel_Reporte_Generador;
    }

    public async Task<byte[]> Handle(Command_Generar_Reporte_Pagos request, CancellationToken cancellationToken)
    {
        var pagos = await _subasta_Servicio.Obtener_Pagos_Reporte_Async(request.Filtro);

        return request.Formato switch
        {
            "pdf" => _pdf_Reporte_Generador.Generar_Reporte_Pagos(pagos),
            "excel" => _excel_Reporte_Generador.Generar_Reporte_Pagos(pagos),
            _ => throw new Formato_No_Soportado_Exception($"Formato {request.Formato} no soportado")
        };
    }
}