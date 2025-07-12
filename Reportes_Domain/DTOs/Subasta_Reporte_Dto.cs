namespace Reportes_Domain.DTOs;

public class Subasta_Reporte_Dto
{
    public Guid SubastaId { get; set; }
    public string? ProductoNombre { get; set; } = string.Empty;
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public decimal? PrecioInicial { get; set; }
    public decimal? PrecioFinal { get; set; }
    public string Estado { get; set; } = string.Empty;
    public List<string> Postores { get; set; } = new List<string>();
}