namespace laboratorio_3_poe.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel _shell = null!;
    private FlowLayoutPanel _sidebar = null!;
    private Label _brand = null!;
    private TableLayoutPanel _userInfoPanel = null!;
    private PictureBox _userIcon = null!;
    private TableLayoutPanel _contentLayout = null!;
    private Panel _content = null!;
    private Label _sessionLabel = null!;
    private Label _pageTitle = null!;
    private FlowLayoutPanel _actions = null!;
    private TextBox _search = null!;
    private Button _addProductButton = null!;
    private Button _editProductButton = null!;
    private Label _stockCriticalLabel = null!;
    private Label _fromLabel = null!;
    private DateTimePicker _fromDate = null!;
    private Label _toLabel = null!;
    private DateTimePicker _toDate = null!;
    private Button _filterSalesButton = null!;
    private Button _exportCsvButton = null!;
    private Button _exportExcelButton = null!;
    private Button _exportPdfButton = null!;
    private DataGridView _grid = null!;
    private Button _navProducts = null!;
    private Button _navSales = null!;
    private Button _navRegister = null!;
    private Button _navEmployees = null!;
    private Button _navLogout = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
            components.Dispose();
        if (disposing)
            _userIcon?.Image?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _shell = new TableLayoutPanel();
        _sidebar = new FlowLayoutPanel();
        _brand = new Label();
        _userInfoPanel = new TableLayoutPanel();
        _userIcon = new PictureBox();
        _contentLayout = new TableLayoutPanel();
        _actions = new FlowLayoutPanel();
        _sessionLabel = new Label();
        _content = new Panel();
        _pageTitle = new Label();
        _search = new TextBox();
        _addProductButton = new Button();
        _editProductButton = new Button();
        _stockCriticalLabel = new Label();
        _fromLabel = new Label();
        _fromDate = new DateTimePicker();
        _toLabel = new Label();
        _toDate = new DateTimePicker();
        _filterSalesButton = new Button();
        _exportCsvButton = new Button();
        _exportExcelButton = new Button();
        _exportPdfButton = new Button();
        _grid = new DataGridView();
        _navProducts = new Button();
        _navSales = new Button();
        _navRegister = new Button();
        _navEmployees = new Button();
        _navLogout = new Button();
        _shell.SuspendLayout();
        _sidebar.SuspendLayout();
        _content.SuspendLayout();
        _contentLayout.SuspendLayout();
        _actions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();
        _shell.ColumnCount = 2;
        _shell.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
        _shell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _shell.Controls.Add(_sidebar, 0, 0);
        _shell.Controls.Add(_content, 1, 0);
        _shell.Dock = DockStyle.Fill;
        _shell.RowCount = 1;
        _shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _sidebar.BackColor = Color.FromArgb(25, 45, 70);
        _sidebar.Controls.Add(_brand);
        _sidebar.Controls.Add(_userInfoPanel);
        _sidebar.Controls.Add(_navProducts);
        _sidebar.Controls.Add(_navSales);
        _sidebar.Controls.Add(_navRegister);
        _sidebar.Controls.Add(_navEmployees);
        _sidebar.Controls.Add(_navLogout);
        _sidebar.Dock = DockStyle.Fill;
        _sidebar.FlowDirection = FlowDirection.TopDown;
        _sidebar.Padding = new Padding(14);
        _sidebar.WrapContents = false;
        _brand.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        _brand.ForeColor = Color.White;
        _brand.Height = 55;
        _brand.Text = "VENTAS";
        _brand.TextAlign = ContentAlignment.MiddleLeft;
        _brand.Width = 190;
        _userInfoPanel.BackColor = Color.Transparent;
        _userInfoPanel.ColumnCount = 2;
        _userInfoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
        _userInfoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _userInfoPanel.Controls.Add(_userIcon, 0, 0);
        _userInfoPanel.Controls.Add(_sessionLabel, 1, 0);
        _userInfoPanel.Margin = new Padding(0, 4, 0, 12);
        _userInfoPanel.RowCount = 1;
        _userInfoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _userInfoPanel.Size = new Size(195, 48);
        _userIcon.BackColor = Color.White;
        _userIcon.Dock = DockStyle.None;
        _userIcon.Margin = new Padding(0, 4, 0, 0);
        _userIcon.Size = new Size(36, 36);
        _userIcon.SizeMode = PictureBoxSizeMode.Zoom;
        _sessionLabel.Dock = DockStyle.Fill;
        _sessionLabel.Font = new Font("Segoe UI", 8.5F);
        _sessionLabel.ForeColor = Color.Gainsboro;
        _sessionLabel.Margin = new Padding(4, 0, 0, 0);
        _sessionLabel.Text = "Sesión: Usuario\r\nRol: Empleado";
        _sessionLabel.TextAlign = ContentAlignment.MiddleLeft;
        ConfigureNavigationButton(_navProducts, "Productos / stock");
        ConfigureNavigationButton(_navSales, "Reporte de ventas");
        ConfigureNavigationButton(_navRegister, "Registrar venta");
        ConfigureNavigationButton(_navEmployees, "Empleados");
        ConfigureNavigationButton(_navLogout, "Cerrar sesión");
        _navLogout.Margin = new Padding(0, 22, 0, 4);
        _content.BackColor = Color.FromArgb(245, 247, 250);
        _content.Controls.Add(_contentLayout);
        _content.Dock = DockStyle.Fill;
        _content.Padding = new Padding(24);
        _contentLayout.ColumnCount = 1;
        _contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _contentLayout.Controls.Add(_pageTitle, 0, 0);
        _contentLayout.Controls.Add(_actions, 0, 1);
        _contentLayout.Controls.Add(_grid, 0, 2);
        _contentLayout.Dock = DockStyle.Fill;
        _contentLayout.RowCount = 3;
        _contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        _contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        _contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _pageTitle.Dock = DockStyle.Fill;
        _pageTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        _pageTitle.Text = "Catálogo de productos";
        _pageTitle.TextAlign = ContentAlignment.MiddleLeft;
        _actions.Controls.Add(_search);
        _actions.Controls.Add(_addProductButton);
        _actions.Controls.Add(_editProductButton);
        _actions.Controls.Add(_stockCriticalLabel);
        _actions.Controls.Add(_fromLabel);
        _actions.Controls.Add(_fromDate);
        _actions.Controls.Add(_toLabel);
        _actions.Controls.Add(_toDate);
        _actions.Controls.Add(_filterSalesButton);
        _actions.Controls.Add(_exportCsvButton);
        _actions.Controls.Add(_exportExcelButton);
        _actions.Controls.Add(_exportPdfButton);
        _actions.Dock = DockStyle.Fill;
        _actions.FlowDirection = FlowDirection.LeftToRight;
        _actions.WrapContents = false;
        _search.Font = new Font("Segoe UI", 10F);
        _search.Margin = new Padding(0, 10, 12, 0);
        _search.PlaceholderText = "Filtrar por nombre...";
        _search.Width = 240;
        ConfigureActionButton(_addProductButton, "Nuevo producto", Color.FromArgb(25, 135, 84));
        ConfigureActionButton(_editProductButton, "Editar seleccionado", Color.FromArgb(13, 110, 253));
        _stockCriticalLabel.AutoSize = true;
        _stockCriticalLabel.ForeColor = Color.Firebrick;
        _stockCriticalLabel.Margin = new Padding(15, 15, 0, 0);
        _stockCriticalLabel.Text = "Rojo: stock crítico (≤ 5)";
        ConfigureFilterLabel(_fromLabel, "Desde:");
        ConfigureFilterLabel(_toLabel, "Hasta:");
        ConfigureDatePicker(_fromDate);
        ConfigureDatePicker(_toDate);
        ConfigureActionButton(_filterSalesButton, "Filtrar", Color.FromArgb(31, 78, 121));
        ConfigureActionButton(_exportCsvButton, "CSV", Color.FromArgb(25, 135, 84));
        ConfigureActionButton(_exportExcelButton, "Excel", Color.FromArgb(33, 115, 70));
        ConfigureActionButton(_exportPdfButton, "PDF", Color.FromArgb(190, 45, 45));
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = Color.White;
        _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 78, 121);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        _grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _grid.ColumnHeadersHeight = 38;
        _grid.EnableHeadersVisualStyles = false;
        _grid.Dock = DockStyle.Fill;
        _grid.MultiSelect = false;
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1180, 720);
        Controls.Add(_shell);
        MinimumSize = new Size(900, 600);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Ventas Electrónica";
        WindowState = FormWindowState.Maximized;
        _shell.ResumeLayout(false);
        _sidebar.ResumeLayout(false);
        _content.ResumeLayout(false);
        _contentLayout.ResumeLayout(false);
        _actions.ResumeLayout(false);
        _actions.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
    }

    private static void ConfigureNavigationButton(Button button, string text)
    {
        button.BackColor = Color.FromArgb(39, 67, 98);
        button.Cursor = Cursors.Hand;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.ForeColor = Color.White;
        button.Height = 44;
        button.Margin = new Padding(0, 8, 0, 4);
        button.Text = text;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Width = 195;
    }

    private static void ConfigureFilterLabel(Label label, string text)
    {
        label.AutoSize = true;
        label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label.ForeColor = Color.FromArgb(45, 55, 72);
        label.Margin = new Padding(6, 18, 2, 0);
        label.Text = text;
    }

    private static void ConfigureDatePicker(DateTimePicker picker)
    {
        picker.Format = DateTimePickerFormat.Short;
        picker.Width = 112;
        picker.Margin = new Padding(2, 12, 4, 0);
    }

    private static void ConfigureActionButton(Button button, string text, Color color)
    {
        button.BackColor = color;
        button.Cursor = Cursors.Hand;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.ForeColor = Color.White;
        button.Height = 36;
        button.Margin = new Padding(0, 8, 8, 0);
        button.Text = text;
        button.AutoSize = true;
    }
}
