namespace Reportes_Domain.DTOs;

public class Filtro_Reporte_Dto
{
    public DateTime Fecha_Inicio { get; set; }
    public DateTime Fecha_Fin { get; set; }
    public string? Categoria { get; set; }
}