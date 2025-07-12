using MediatR;
using Reportes_Domain.DTOs;

namespace Reportes_Application.Commands;

public class Command_Generar_Reporte_Pujas : IRequest<byte[]>
{
    public Filtro_Pujas_Dto Filtro { get; }
    public string Formato { get; }

    public Command_Generar_Reporte_Pujas(Filtro_Pujas_Dto filtro, string formato)
    {
        Filtro = filtro;
        Formato = formato.ToLower();
    }
}
