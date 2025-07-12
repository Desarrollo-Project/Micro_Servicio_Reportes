using Reportes_Domain.DTOs;

namespace Reportes_Infrastructure.Interfaces;

public interface ISubasta_Servicio
{
    Task<IEnumerable<Subasta_Reporte_Dto>> Obtener_Subastas_Reporte_Async(Filtro_Reporte_Dto filtro);
    Task<IEnumerable<Puja_Reporte_Dto>> Obtener_Pujas_Reporte_Async(Filtro_Pujas_Dto filtro);
    Task<IEnumerable<Pago_Reporte_Dto>> Obtener_Pagos_Reporte_Async(Filtro_Pagos_Dto filtro);

}
