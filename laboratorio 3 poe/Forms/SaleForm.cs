using laboratorio_3_poe.Models;

namespace laboratorio_3_poe.Forms;

public sealed partial class SaleForm : Form
{
    public Product SelectedProduct => (Product)_products.SelectedItem!;
    public int Quantity => (int)_quantity.Value;

    public SaleForm() : this(Array.Empty<Product>())
    {
    }

    public SaleForm(IReadOnlyList<Product> products)
    {
        InitializeComponent();
        _products.DataSource = products.Where(p => p.Stock > 0).ToList();
        _products.DisplayMember = nameof(Product.Name);
        _products.SelectedIndexChanged += (_, _) => UpdateAvailableStock();
        _quantity.ValueChanged += (_, _) => UpdatePriceAndTotal();
        _confirm.Click += (_, _) => { DialogResult = DialogResult.OK; Close(); };
        UpdateAvailableStock();
    }

    private void UpdateAvailableStock()
    {
        if (_products.SelectedItem is Product product)
            _quantity.Maximum = Math.Max(1, product.Stock);
        UpdatePriceAndTotal();
    }

    private void UpdatePriceAndTotal()
    {
        if (_products.SelectedItem is not Product product)
        {
            _price.Clear();
            _total.Clear();
            return;
        }

        _price.Text = product.Price.ToString("C2");
        _total.Text = (product.Price * _quantity.Value).ToString("C2");
    }
}
