namespace Reportes_Domain.DTOs;

public class Pago_Reporte_Dto
{
    public Guid Pago_Id { get; set; }
    public Guid Subasta_Id { get; set; }
    public string Producto_Nombre { get; set; } = string.Empty;
    public string Usuario_Comprador { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime Fecha_Pago { get; set; }
}