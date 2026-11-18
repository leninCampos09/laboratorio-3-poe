namespace laboratorio_3_poe.Forms;

partial class ProductForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel _layout = null!;
    private Label _nameLabel = null!;
    private Label _descriptionLabel = null!;
    private Label _priceLabel = null!;
    private Label _stockLabel = null!;
    private TextBox _name = null!;
    private TextBox _description = null!;
    private NumericUpDown _price = null!;
    private NumericUpDown _stock = null!;
    private Button _save = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _layout = new TableLayoutPanel();
        _nameLabel = new Label();
        _name = new TextBox();
        _descriptionLabel = new Label();
        _description = new TextBox();
        _priceLabel = new Label();
        _price = new NumericUpDown();
        _stockLabel = new Label();
        _stock = new NumericUpDown();
        _save = new Button();
        _layout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_price).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_stock).BeginInit();
        SuspendLayout();
        // 
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_nameLabel, 0, 0);
        _layout.Controls.Add(_name, 1, 0);
        _layout.Controls.Add(_descriptionLabel, 0, 1);
        _layout.Controls.Add(_description, 1, 1);
        _layout.Controls.Add(_priceLabel, 0, 2);
        _layout.Controls.Add(_price, 1, 2);
        _layout.Controls.Add(_stockLabel, 0, 3);
        _layout.Controls.Add(_stock, 1, 3);
        _layout.Controls.Add(_save, 1, 4);
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
        _layout.Size = new Size(430, 310);
        _layout.TabIndex = 0;
        // 
        // _nameLabel
        // 
        _nameLabel.AutoSize = true;
        _nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _nameLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _nameLabel.Location = new Point(23, 20);
        _nameLabel.Name = "_nameLabel";
        _nameLabel.Size = new Size(56, 15);
        _nameLabel.TabIndex = 0;
        _nameLabel.Text = "Nombre:";
        // 
        // _name
        // 
        _name.Dock = DockStyle.Fill;
        _name.Location = new Point(138, 23);
        _name.Name = "_name";
        _name.Size = new Size(269, 23);
        _name.TabIndex = 1;
        // 
        // _descriptionLabel
        // 
        _descriptionLabel.AutoSize = true;
        _descriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _descriptionLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _descriptionLabel.Location = new Point(23, 68);
        _descriptionLabel.Name = "_descriptionLabel";
        _descriptionLabel.Size = new Size(75, 15);
        _descriptionLabel.TabIndex = 2;
        _descriptionLabel.Text = "Descripción:";
        // 
        // _description
        // 
        _description.Dock = DockStyle.Fill;
        _description.Location = new Point(138, 71);
        _description.Name = "_description";
        _description.Size = new Size(269, 23);
        _description.TabIndex = 3;
        // 
        // _priceLabel
        // 
        _priceLabel.AutoSize = true;
        _priceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _priceLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _priceLabel.Location = new Point(23, 116);
        _priceLabel.Name = "_priceLabel";
        _priceLabel.Size = new Size(45, 15);
        _priceLabel.TabIndex = 4;
        _priceLabel.Text = "Precio:";
        // 
        // _price
        // 
        _price.DecimalPlaces = 2;
        _price.Dock = DockStyle.Fill;
        _price.Location = new Point(138, 119);
        _price.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        _price.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
        _price.Name = "_price";
        _price.Size = new Size(269, 23);
        _price.TabIndex = 5;
        _price.Value = new decimal(new int[] { 1, 0, 0, 131072 });
        // 
        // _stockLabel
        // 
        _stockLabel.AutoSize = true;
        _stockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _stockLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _stockLabel.Location = new Point(23, 164);
        _stockLabel.Name = "_stockLabel";
        _stockLabel.Size = new Size(58, 15);
        _stockLabel.TabIndex = 6;
        _stockLabel.Text = "Cantidad:";
        // 
        // _stock
        // 
        _stock.Dock = DockStyle.Fill;
        _stock.Location = new Point(138, 167);
        _stock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        _stock.Name = "_stock";
        _stock.Size = new Size(269, 23);
        _stock.TabIndex = 7;
        // 
        // _save
        // 
        _save.Anchor = AnchorStyles.Right;
        _save.BackColor = Color.FromArgb(25, 135, 84);
        _save.Cursor = Cursors.Hand;
        _save.FlatAppearance.BorderSize = 0;
        _save.FlatStyle = FlatStyle.Flat;
        _save.ForeColor = Color.White;
        _save.Location = new Point(297, 233);
        _save.Name = "_save";
        _save.Size = new Size(110, 36);
        _save.TabIndex = 8;
        _save.Text = "Guardar";
        _save.UseVisualStyleBackColor = false;
        // 
        // ProductForm
        // 
        AcceptButton = _save;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(430, 310);
        Controls.Add(_layout);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Producto";
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_price).EndInit();
        ((System.ComponentModel.ISupportInitialize)_stock).EndInit();
        ResumeLayout(false);
    }

    private static void ConfigureLabel(Label label, string text)
    {
        label.Anchor = AnchorStyles.Left;
        label.AutoSize = true;
        label.Text = text;
    }
}
