using MediatR;
using Reportes_Domain.DTOs;

namespace Reportes_Application.Commands;

public class Command_Generar_Reporte_Subastas : IRequest<byte[]>
{
    public Filtro_Reporte_Dto Filtro { get; set; }
    public string Formato { get; set; }

    public Command_Generar_Reporte_Subastas(Filtro_Reporte_Dto filtro, string formato)
    {
        Filtro = filtro;
        Formato = formato.ToLower();
    }
}