using RepoDb.Attributes;

namespace laboratorio_3_poe.Models;

[Map("SaleDetails")]
public sealed class SaleDetail
{
    [Primary, Identity]
    public int SaleDetailId { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
