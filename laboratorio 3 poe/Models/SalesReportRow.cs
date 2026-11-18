namespace laboratorio_3_poe.Models;

public sealed class SalesReportRow
{
    public int ProductId { get; set; }
    public string Product { get; set; } = "";
    public int UnitsSold { get; set; }
    public decimal TotalAmount { get; set; }
}
