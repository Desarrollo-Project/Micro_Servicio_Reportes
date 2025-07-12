using Reportes_Domain.DTOs;
using MediatR;

namespace Reportes_Application.Commands;

public class Command_Generar_Reporte_Pagos : IRequest<byte[]>
{
    public Filtro_Pagos_Dto Filtro { get; }
    public string Formato { get; }


    public Command_Generar_Reporte_Pagos(Filtro_Pagos_Dto filtro, string formato)
    {
        Filtro = filtro;
        Formato = formato.ToLower();
    }
}