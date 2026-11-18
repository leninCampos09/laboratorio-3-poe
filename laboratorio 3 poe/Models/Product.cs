using RepoDb.Attributes;

namespace laboratorio_3_poe.Models;

[Map("Products")]
public sealed class Product
{
    [Primary, Identity]
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
