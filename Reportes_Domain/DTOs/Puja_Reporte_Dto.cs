namespace Reportes_Domain.DTOs;

public class Puja_Reporte_Dto
{
    public Guid Subasta_Id { get; set; }
    public string Producto_Nombre { get; set; } = string.Empty;
    public DateTime Fecha_Puja { get; set; }
    public decimal Monto { get; set; }
    public bool Ganador { get; set; }
}