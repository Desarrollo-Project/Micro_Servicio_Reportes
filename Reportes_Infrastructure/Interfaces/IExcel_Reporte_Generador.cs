using Reportes_Domain.DTOs;
namespace Reportes_Infrastructure.Interfaces;

public interface IExcel_Reporte_Generador
{
    byte[] Generar_Reporte_Subastas(IEnumerable<Subasta_Reporte_Dto> subastas);
    byte[] Generar_Reporte_Pujas(IEnumerable<Puja_Reporte_Dto> pujas);
    byte[] Generar_Reporte_Pagos(IEnumerable<Pago_Reporte_Dto> pagos);
}