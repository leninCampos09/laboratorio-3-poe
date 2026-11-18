using System.Globalization;
using System.Text;
using ClosedXML.Excel;
using laboratorio_3_poe.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace laboratorio_3_poe.Services;

public sealed class ReportExportService
{
    private const string CompanyName = "Ventas Electrónica";
    private static readonly CultureInfo ReportCulture = CultureInfo.GetCultureInfo("es-SV");

    public void ExportCsv(string path, IReadOnlyList<SalesReportRow> rows, DateTime startDate, DateTime endDate)
    {
        using var writer = new StreamWriter(path, false, new UTF8Encoding(true));
        writer.WriteLine(CsvRow(CompanyName));
        writer.WriteLine(CsvRow("Reporte de ventas", $"Desde {startDate:d} hasta {endDate:d}"));
        writer.WriteLine(CsvRow("Producto", "Unidades vendidas", "Monto acumulado"));
        foreach (var row in rows)
            writer.WriteLine(CsvRow(row.Product, row.UnitsSold.ToString(ReportCulture), row.TotalAmount.ToString("0.00", ReportCulture)));
        writer.WriteLine(CsvRow("TOTAL", rows.Sum(row => row.UnitsSold).ToString(ReportCulture), rows.Sum(row => row.TotalAmount).ToString("0.00", ReportCulture)));
    }

    public void ExportExcel(string path, IReadOnlyList<SalesReportRow> rows, DateTime startDate, DateTime endDate)
    {
        using var workbook = new XLWorkbook();
        var sheet = workbook.Worksheets.Add("Reporte de ventas");
        sheet.Cell(1, 1).Value = CompanyName;
        sheet.Cell(2, 1).Value = "Reporte de ventas";
        sheet.Cell(3, 1).Value = "Período";
        sheet.Cell(3, 2).Value = $"{startDate:d} - {endDate:d}";
        sheet.Cell(5, 1).Value = "Producto";
        sheet.Cell(5, 2).Value = "Unidades vendidas";
        sheet.Cell(5, 3).Value = "Monto acumulado";
        sheet.Range(1, 1, 1, 3).Merge();
        sheet.Range(1, 1, 1, 3).Style.Font.Bold = true;
        sheet.Range(1, 1, 1, 3).Style.Font.FontSize = 16;
        sheet.Range(2, 1, 2, 3).Merge();
        sheet.Range(2, 1, 2, 3).Style.Font.Bold = true;
        sheet.Range(5, 1, 5, 3).Style.Font.Bold = true;
        sheet.Range(5, 1, 5, 3).Style.Fill.BackgroundColor = XLColor.FromHtml("#1F4E79");
        sheet.Range(5, 1, 5, 3).Style.Font.FontColor = XLColor.White;

        var rowIndex = 6;
        foreach (var row in rows)
        {
            sheet.Cell(rowIndex, 1).Value = row.Product;
            sheet.Cell(rowIndex, 2).Value = row.UnitsSold;
            sheet.Cell(rowIndex, 3).Value = row.TotalAmount;
            sheet.Cell(rowIndex, 3).Style.NumberFormat.Format = "$ #,##0.00";
            rowIndex++;
        }

        sheet.Cell(rowIndex, 1).Value = "TOTAL";
        sheet.Cell(rowIndex, 2).Value = rows.Sum(row => row.UnitsSold);
        sheet.Cell(rowIndex, 3).Value = rows.Sum(row => row.TotalAmount);
        sheet.Cell(rowIndex, 3).Style.NumberFormat.Format = "$ #,##0.00";
        sheet.Range(rowIndex, 1, rowIndex, 3).Style.Font.Bold = true;
        sheet.Columns(1, 3).AdjustToContents();
        sheet.SheetView.FreezeRows(5);
        workbook.SaveAs(path);
    }

    public void ExportPdf(string path, IReadOnlyList<SalesReportRow> rows, DateTime startDate, DateTime endDate)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Document.Create(document => document.Page(page =>
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(32);
            page.DefaultTextStyle(style => style.FontSize(10));
            page.Header().Column(column =>
            {
                column.Item().Text(CompanyName).FontSize(14).Bold().FontColor(Colors.Grey.Darken2);
                column.Item().PaddingTop(4).Text("Reporte de ventas").FontSize(20).Bold().FontColor(Colors.Blue.Darken3);
                column.Item().PaddingTop(4).Text($"Período: {startDate:d} - {endDate:d}");
            });
            page.Content().PaddingVertical(18).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(4);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });
                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Producto");
                    header.Cell().Element(HeaderCell).AlignRight().Text("Unidades vendidas");
                    header.Cell().Element(HeaderCell).AlignRight().Text("Monto acumulado");
                });
                foreach (var row in rows)
                {
                    table.Cell().Element(BodyCell).Text(row.Product);
                    table.Cell().Element(BodyCell).AlignRight().Text(row.UnitsSold.ToString(ReportCulture));
                    table.Cell().Element(BodyCell).AlignRight().Text(row.TotalAmount.ToString("C2", ReportCulture));
                }
                table.Cell().Element(TotalCell).Text("TOTAL");
                table.Cell().Element(TotalCell).AlignRight().Text(rows.Sum(row => row.UnitsSold).ToString(ReportCulture));
                table.Cell().Element(TotalCell).AlignRight().Text(rows.Sum(row => row.TotalAmount).ToString("C2", ReportCulture));
            });
            page.Footer().AlignCenter().Text(text =>
            {
                text.Span("Generado el ");
                text.Span(DateTime.Now.ToString("g", ReportCulture));
            });
        })).GeneratePdf(path);
    }

    private static IContainer HeaderCell(IContainer container) =>
        container.Background(Colors.Blue.Darken3).Padding(7).DefaultTextStyle(style => style.FontColor(Colors.White).SemiBold());

    private static IContainer BodyCell(IContainer container) =>
        container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(7);

    private static IContainer TotalCell(IContainer container) =>
        container.Background(Colors.Grey.Lighten3).Padding(7).DefaultTextStyle(style => style.SemiBold());

    private static string CsvRow(params string[] values) => string.Join(",", values.Select(value => $"\"{value.Replace("\"", "\"\"")}\""));
}
