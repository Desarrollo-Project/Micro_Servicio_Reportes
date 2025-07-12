using MediatR;
using Reportes_Application.Commands;
using Reportes_Infrastructure.Interfaces;
using Reportes_Domain.Exceptions;

namespace Reportes_Application.Handlers;

public class Handler_Generar_Reporte_Pujas : IRequestHandler<Command_Generar_Reporte_Pujas, byte[]>
{
    private readonly ISubasta_Servicio _subasta_Servicio;
    private readonly IPdf_Reporte_Generador _pdf_Reporte_Generador;
    private readonly IExcel_Reporte_Generador _excel_Reporte_Generador;

    public Handler_Generar_Reporte_Pujas(ISubasta_Servicio subasta_Servicio, IPdf_Reporte_Generador pdf_Reporte_Generador, IExcel_Reporte_Generador excel_Reporte_Generador)
    {
        _subasta_Servicio = subasta_Servicio;
        _pdf_Reporte_Generador = pdf_Reporte_Generador;
        _excel_Reporte_Generador = excel_Reporte_Generador;
    }

    public async Task<byte[]> Handle(Command_Generar_Reporte_Pujas request, CancellationToken cancellationToken)
    {
        var pujas = await _subasta_Servicio.Obtener_Pujas_Reporte_Async(request.Filtro);
        
        return request.Formato switch
        {
            "pdf" => _pdf_Reporte_Generador.Generar_Reporte_Pujas(pujas),
            "excel" => _excel_Reporte_Generador.Generar_Reporte_Pujas(pujas),
            _ => throw new Formato_No_Soportado_Exception($"Formato {request.Formato} no soportado")
        };
    }
}