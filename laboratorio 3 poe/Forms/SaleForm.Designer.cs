namespace laboratorio_3_poe.Forms;

partial class SaleForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel _layout = null!;
    private Label _productLabel = null!;
    private Label _quantityLabel = null!;
    private Label _priceLabel = null!;
    private Label _totalLabel = null!;
    private ComboBox _products = null!;
    private NumericUpDown _quantity = null!;
    private TextBox _price = null!;
    private TextBox _total = null!;
    private Button _confirm = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _layout = new TableLayoutPanel();
        _productLabel = new Label();
        _products = new ComboBox();
        _quantityLabel = new Label();
        _quantity = new NumericUpDown();
        _priceLabel = new Label();
        _price = new TextBox();
        _totalLabel = new Label();
        _total = new TextBox();
        _confirm = new Button();
        _layout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_quantity).BeginInit();
        SuspendLayout();
        // 
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_productLabel, 0, 0);
        _layout.Controls.Add(_products, 1, 0);
        _layout.Controls.Add(_quantityLabel, 0, 1);
        _layout.Controls.Add(_quantity, 1, 1);
        _layout.Controls.Add(_priceLabel, 0, 2);
        _layout.Controls.Add(_price, 1, 2);
        _layout.Controls.Add(_totalLabel, 0, 3);
        _layout.Controls.Add(_total, 1, 3);
        _layout.Controls.Add(_confirm, 1, 4);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 0);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(20);
        _layout.RowCount = 5;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.Size = new Size(460, 320);
        _layout.TabIndex = 0;
        // 
        // _productLabel
        // 
        _productLabel.AutoSize = true;
        _productLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _productLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _productLabel.Location = new Point(23, 20);
        _productLabel.Name = "_productLabel";
        _productLabel.Size = new Size(61, 15);
        _productLabel.TabIndex = 0;
        _productLabel.Text = "Producto:";
        // 
        // _products
        // 
        _products.Dock = DockStyle.Fill;
        _products.DropDownStyle = ComboBoxStyle.DropDownList;
        _products.Location = new Point(133, 23);
        _products.Name = "_products";
        _products.Size = new Size(304, 23);
        _products.TabIndex = 1;
        // 
        // _quantityLabel
        // 
        _quantityLabel.AutoSize = true;
        _quantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _quantityLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _quantityLabel.Location = new Point(23, 68);
        _quantityLabel.Name = "_quantityLabel";
        _quantityLabel.Size = new Size(58, 15);
        _quantityLabel.TabIndex = 2;
        _quantityLabel.Text = "Cantidad:";
        // 
        // _quantity
        // 
        _quantity.Dock = DockStyle.Fill;
        _quantity.Location = new Point(133, 71);
        _quantity.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
        _quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        _quantity.Name = "_quantity";
        _quantity.Size = new Size(304, 23);
        _quantity.TabIndex = 3;
        _quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // _priceLabel
        // 
        _priceLabel.AutoSize = true;
        _priceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _priceLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _priceLabel.Location = new Point(23, 116);
        _priceLabel.Name = "_priceLabel";
        _priceLabel.Size = new Size(91, 15);
        _priceLabel.TabIndex = 4;
        _priceLabel.Text = "Precio unitario:";
        // 
        // _price
        // 
        _price.BackColor = Color.FromArgb(240, 243, 247);
        _price.Dock = DockStyle.Fill;
        _price.Location = new Point(133, 119);
        _price.Name = "_price";
        _price.ReadOnly = true;
        _price.Size = new Size(304, 23);
        _price.TabIndex = 5;
        _price.TabStop = false;
        // 
        // _totalLabel
        // 
        _totalLabel.AutoSize = true;
        _totalLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _totalLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _totalLabel.Location = new Point(23, 164);
        _totalLabel.Name = "_totalLabel";
        _totalLabel.Size = new Size(37, 15);
        _totalLabel.TabIndex = 6;
        _totalLabel.Text = "Total:";
        // 
        // _total
        // 
        _total.BackColor = Color.FromArgb(240, 243, 247);
        _total.Dock = DockStyle.Fill;
        _total.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _total.Location = new Point(133, 167);
        _total.Name = "_total";
        _total.ReadOnly = true;
        _total.Size = new Size(304, 25);
        _total.TabIndex = 7;
        _total.TabStop = false;
        // 
        // _confirm
        // 
        _confirm.Anchor = AnchorStyles.Right;
        _confirm.BackColor = Color.FromArgb(13, 110, 253);
        _confirm.Cursor = Cursors.Hand;
        _confirm.FlatAppearance.BorderSize = 0;
        _confirm.FlatStyle = FlatStyle.Flat;
        _confirm.ForeColor = Color.White;
        _confirm.Location = new Point(297, 238);
        _confirm.Name = "_confirm";
        _confirm.Size = new Size(140, 36);
        _confirm.TabIndex = 4;
        _confirm.Text = "Confirmar venta";
        _confirm.UseVisualStyleBackColor = false;
        // 
        // SaleForm
        // 
        AcceptButton = _confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(460, 320);
        Controls.Add(_layout);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SaleForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Registrar venta";
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_quantity).EndInit();
        ResumeLayout(false);
    }

    private static void ConfigureLabel(Label label, string text)
    {
        label.Anchor = AnchorStyles.Left;
        label.AutoSize = true;
        label.Text = text;
    }
}
