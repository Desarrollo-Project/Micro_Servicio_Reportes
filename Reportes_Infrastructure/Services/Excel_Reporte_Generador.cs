using Reportes_Domain.DTOs; 
using Reportes_Infrastructure.Interfaces;
using ClosedXML.Excel;

namespace Reportes_Infrastructure.Services;

public class Excel_Reporte_Generador: IExcel_Reporte_Generador
{
    public byte[] Generar_Reporte_Subastas(IEnumerable<Subasta_Reporte_Dto> subastas)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Subastas");

        // Cabeceras
        worksheet.Cell(1, 1).Value = "Producto";
        worksheet.Cell(1, 2).Value = "Fecha Inicio";
        worksheet.Cell(1, 3).Value = "Fecha Fin";
        worksheet.Cell(1, 4).Value = "Precio Inicial";
        worksheet.Cell(1, 5).Value = "Precio Final";
        worksheet.Cell(1, 6).Value = "Postores";

        // Datos
        int row = 2;
        foreach (var subasta in subastas)
        {
            worksheet.Cell(row, 1).Value = subasta.ProductoNombre;
            worksheet.Cell(row, 2).Value = subasta.FechaInicio;
            worksheet.Cell(row, 3).Value = subasta.FechaFin;
            worksheet.Cell(row, 4).Value = subasta.PrecioInicial;
            worksheet.Cell(row, 5).Value = subasta.PrecioFinal;
            worksheet.Cell(row, 6).Value = string.Join(", ", subasta.Postores);
            row++;
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] Generar_Reporte_Pujas(IEnumerable<Puja_Reporte_Dto> pujas)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Pujas");

        // Cabeceras
        worksheet.Cell(1, 1).Value = "Subasta ID";
        worksheet.Cell(1, 2).Value = "Producto";
        worksheet.Cell(1, 3).Value = "Fecha Puja";
        worksheet.Cell(1, 4).Value = "Monto";
        worksheet.Cell(1, 5).Value = "Resultado";

        // Datos
        int row = 2;
        foreach (var puja in pujas)
        {
            worksheet.Cell(row, 1).Value = puja.Subasta_Id.ToString();
            worksheet.Cell(row, 2).Value = puja.Producto_Nombre;
            worksheet.Cell(row, 3).Value = puja.Fecha_Puja.ToString("g");
            worksheet.Cell(row, 4).Value = puja.Monto.ToString("C");
            worksheet.Cell(row, 5).Value = puja.Ganador ? "Ganador" : "No ganador";
            row++;
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] Generar_Reporte_Pagos(IEnumerable<Pago_Reporte_Dto> pagos)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Pagos");

        // Cabeceras
        worksheet.Cell(1, 1).Value = "Subasta ID";
        worksheet.Cell(1, 2).Value = "Producto";
        worksheet.Cell(1, 3).Value = "Comprador";
        worksheet.Cell(1, 4).Value = "Monto";
        worksheet.Cell(1, 5).Value = "Método Pago";
        worksheet.Cell(1, 6).Value = "Estado";
        worksheet.Cell(1, 7).Value = "Fecha Pago";

        // Datos
        int row = 2;
        foreach (var pago in pagos)
        {
            worksheet.Cell(row, 1).Value = pago.Subasta_Id.ToString();
            worksheet.Cell(row, 2).Value = pago.Producto_Nombre;
            worksheet.Cell(row, 3).Value = pago.Usuario_Comprador;
            worksheet.Cell(row, 4).Value = pago.Monto;
            worksheet.Cell(row, 6).Value = pago.Estado;
            worksheet.Cell(row, 7).Value = pago.Fecha_Pago.ToString("g");
            row++;
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}