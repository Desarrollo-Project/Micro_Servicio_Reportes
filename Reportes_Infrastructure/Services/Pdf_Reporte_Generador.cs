using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Reportes_Domain.DTOs;
using Reportes_Infrastructure.Interfaces;

namespace Reportes_Infrastructure.Services;

public class Pdf_Reporte_Generador: IPdf_Reporte_Generador
{
    public byte[] Generar_Reporte_Subastas(IEnumerable<Subasta_Reporte_Dto> subastas)
    {
        using var memoryStream = new MemoryStream();
        var writer = new PdfWriter(memoryStream);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        // Título
        document.Add(new Paragraph("Reporte de Subastas Realizadas")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(16));

        // Tabla
        var table = new Table(6);
        table.AddHeaderCell("Producto");
        table.AddHeaderCell("Fecha Inicio");
        table.AddHeaderCell("Fecha Fin");
        table.AddHeaderCell("Precio Inicial");
        table.AddHeaderCell("Precio Final");
        table.AddHeaderCell("Postores");

        foreach (var subasta in subastas)
        {
            table.AddCell(subasta.ProductoNombre);
            table.AddCell(subasta.FechaInicio.ToString());
            table.AddCell(subasta.FechaFin.ToString());
            table.AddCell(subasta.PrecioInicial.ToString());
            table.AddCell(subasta.PrecioFinal?.ToString() ?? "N/A");
            table.AddCell(string.Join(", ", subasta.Postores));
        }

        document.Add(table);
        document.Close();

        return memoryStream.ToArray();
    }

    public byte[] Generar_Reporte_Pujas(IEnumerable<Puja_Reporte_Dto> pujas)
    {
        using var memoryStream = new MemoryStream();
        var writer = new PdfWriter(memoryStream);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        document.Add(new Paragraph("Reporte de Pujas por Usuario")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(16));

        var table = new Table(5);
        table.AddHeaderCell("Subasta");
        table.AddHeaderCell("Producto");
        table.AddHeaderCell("Fecha Puja");
        table.AddHeaderCell("Monto");
        table.AddHeaderCell("Resultado");

        foreach (var puja in pujas)
        {
            table.AddCell(puja.Subasta_Id.ToString());
            table.AddCell(puja.Producto_Nombre);
            table.AddCell(puja.Fecha_Puja.ToString("g"));
            table.AddCell(puja.Monto.ToString("C"));
            table.AddCell(puja.Ganador ? "Ganador" : "No ganador");
        }

        document.Add(table);
        document.Close();

        return memoryStream.ToArray();
    }

    public byte[] Generar_Reporte_Pagos(IEnumerable<Pago_Reporte_Dto> pagos)
    {
        using var memoryStream = new MemoryStream();
        var writer = new PdfWriter(memoryStream);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        document.Add(new Paragraph("Reporte de Pagos Recibidos")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(16));

        var table = new Table(7);
        table.AddHeaderCell("Subasta");
        table.AddHeaderCell("Producto");
        table.AddHeaderCell("Comprador");
        table.AddHeaderCell("Monto");
        table.AddHeaderCell("Método Pago");
        table.AddHeaderCell("Estado");
        table.AddHeaderCell("Fecha Pago");

        foreach (var pago in pagos)
        {
            table.AddCell(pago.Subasta_Id.ToString());
            table.AddCell(pago.Producto_Nombre);
            table.AddCell(pago.Usuario_Comprador);
            table.AddCell(pago.Monto.ToString("C"));
            table.AddCell(pago.Estado);
            table.AddCell(pago.Fecha_Pago.ToString("g"));
        }

        document.Add(table);
        document.Close();

        return memoryStream.ToArray();
    }
}