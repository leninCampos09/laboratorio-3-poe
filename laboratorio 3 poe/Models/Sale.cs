using RepoDb.Attributes;

namespace laboratorio_3_poe.Models;

[Map("Sales")]
public sealed class Sale
{
    [Primary, Identity]
    public int SaleId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime SoldAt { get; set; }
}
