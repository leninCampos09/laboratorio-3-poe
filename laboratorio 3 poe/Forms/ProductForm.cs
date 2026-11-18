using laboratorio_3_poe.Models;

namespace laboratorio_3_poe.Forms;

public sealed partial class ProductForm : Form
{
    public Product Product { get; private set; }

    public ProductForm() : this(null)
    {
    }

    public ProductForm(Product? product)
    {
        InitializeComponent();
        Product = product is null ? new Product() : new Product
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock
        };

        Text = product is null ? "Nuevo producto" : "Editar producto";
        _name.Text = Product.Name;
        _description.Text = Product.Description;
        _price.Value = Product.Price >= _price.Minimum ? Product.Price : _price.Minimum;
        _stock.Value = Math.Clamp(Product.Stock, 0, 1000000);
        _save.Click += Save;
    }

    private void Save(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_name.Text))
        {
            MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        Product.Name = _name.Text.Trim();
        Product.Description = _description.Text.Trim();
        Product.Price = _price.Value;
        Product.Stock = (int)_stock.Value;
        DialogResult = DialogResult.OK;
        Close();
    }
}
