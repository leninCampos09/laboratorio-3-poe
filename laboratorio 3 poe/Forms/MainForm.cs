using laboratorio_3_poe.Data;
using laboratorio_3_poe.Models;
using laboratorio_3_poe.Services;

namespace laboratorio_3_poe.Forms;

public sealed partial class MainForm : Form
{
    private readonly Employee _employee;
    private readonly IRepository<Product> _products = new RepoDbRepository<Product>();
    private readonly IRepository<Employee> _employees = new RepoDbRepository<Employee>();
    private readonly SalesRepository _sales = new();
    private readonly ReportExportService _reportExporter = new();
    private List<Product> _loadedProducts = [];
    private List<Employee> _loadedEmployees = [];
    private bool _showingEmployees;
    private IReadOnlyList<SalesReportRow> _currentReport = [];

    public MainForm() : this(new Employee { FullName = "Vista previa", Role = "Administrador" })
    {
    }

    public MainForm(Employee employee)
    {
        _employee = employee;
        InitializeComponent();
        _sessionLabel.Text = $"Sesión: {_employee.FullName}\r\nRol: {(_employee.IsAdministrator ? "Administrador" : _employee.Role)}";
        _userIcon.Resize += (_, _) => ApplyCircularAvatarMask();
        _userIcon.Paint += (_, e) =>
        {
            using var border = new Pen(Color.FromArgb(190, 210, 230), 1.5F);
            e.Graphics.DrawEllipse(border, 0.75F, 0.75F, _userIcon.Width - 1.5F, _userIcon.Height - 1.5F);
        };
        ApplyCircularAvatarMask();
        if (!DesignMode)
        {
            var iconPath = Path.Combine(AppContext.BaseDirectory, "icons", "user.png");
            using var icon = Image.FromFile(iconPath);
            _userIcon.Image = new Bitmap(icon);
        }
        _navEmployees.Visible = _employee.IsAdministrator;
        _navProducts.Click += (_, _) => ShowProducts(false);
        _navSales.Click += (_, _) => ShowSalesReport();
        _navRegister.Click += (_, _) => RegisterSale();
        _navEmployees.Click += (_, _) => ShowEmployees();
        _navLogout.Click += (_, _) =>
        {
            var result = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        };
        _addProductButton.Click += (_, _) =>
        {
            if (_showingEmployees) AddEmployee();
            else AddProduct();
        };
        _editProductButton.Click += (_, _) =>
        {
            if (_showingEmployees) EditEmployee();
            else EditProduct();
        };
        _search.TextChanged += (_, _) =>
        {
            if (_showingEmployees) FilterEmployees();
            else FilterProducts();
        };
        _fromDate.Value = DateTime.Today.AddDays(-30);
        _toDate.Value = DateTime.Today;
        _filterSalesButton.Click += (_, _) => FilterSalesReport();
        _exportCsvButton.Click += (_, _) => ExportReport("CSV", ".csv", "Archivo CSV (*.csv)|*.csv", path => _reportExporter.ExportCsv(path, _currentReport, _fromDate.Value, _toDate.Value));
        _exportExcelButton.Click += (_, _) => ExportReport("Excel", ".xlsx", "Libro de Excel (*.xlsx)|*.xlsx", path => _reportExporter.ExportExcel(path, _currentReport, _fromDate.Value, _toDate.Value));
        _exportPdfButton.Click += (_, _) => ExportReport("PDF", ".pdf", "Documento PDF (*.pdf)|*.pdf", path => _reportExporter.ExportPdf(path, _currentReport, _fromDate.Value, _toDate.Value));
        _grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && _grid.Rows[e.RowIndex].DataBoundItem is Product product && product.Stock <= 5)
            {
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.ForeColor = Color.DarkRed;
            }
        };
        if (!DesignMode)
            Shown += (_, _) => ShowProducts(false);
    }

    private void ShowProducts(bool stockOnly)
    {
        try
        {
            _showingEmployees = false;
            _loadedProducts = _products.GetAll().OrderBy(p => p.Name).ToList();
            _pageTitle.Text = stockOnly ? "Consulta de existencias" : "Catálogo de productos";
            _actions.Visible = true;
            _search.PlaceholderText = "Filtrar por nombre de producto...";
            _addProductButton.Text = "Nuevo producto";
            _editProductButton.Text = "Editar seleccionado";
            _search.Visible = true;
            _addProductButton.Visible = !stockOnly;
            _editProductButton.Visible = !stockOnly;
            _stockCriticalLabel.Visible = true;
            SetReportControlsVisible(false);
            FilterProducts();
        }
        catch (Exception exception)
        {
            ShowError("No se pudo consultar el catálogo", exception);
        }
    }

    private void FilterProducts()
    {
        var text = _search.Text.Trim();
        _grid.DataSource = _loadedProducts
            .Where(p => p.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    private void ShowEmployees()
    {
        if (!_employee.IsAdministrator)
        {
            MessageBox.Show("Solo un administrador puede gestionar empleados.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _showingEmployees = true;
            _loadedEmployees = _employees.GetAll().OrderBy(item => item.FullName).ToList();
            _pageTitle.Text = "Administración de empleados";
            _actions.Visible = true;
            _search.Visible = true;
            _search.PlaceholderText = "Filtrar por nombre o usuario...";
            _addProductButton.Visible = true;
            _addProductButton.Text = "Nuevo empleado";
            _editProductButton.Visible = true;
            _editProductButton.Text = "Editar seleccionado";
            _stockCriticalLabel.Visible = false;
            SetReportControlsVisible(false);
            FilterEmployees();
        }
        catch (Exception exception)
        {
            ShowError("No se pudo consultar la lista de empleados", exception);
        }
    }

    private void FilterEmployees()
    {
        var text = _search.Text.Trim();
        _grid.DataSource = _loadedEmployees
            .Where(employee => employee.FullName.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                || employee.Username.Contains(text, StringComparison.CurrentCultureIgnoreCase))
            .Select(employee => new EmployeeListRow
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                Username = employee.Username,
                Role = employee.Role,
                Status = employee.IsActive ? "Activo" : "Inactivo"
            })
            .ToList();
    }

    private void ShowSalesReport()
    {
        _showingEmployees = false;
        _pageTitle.Text = "Productos vendidos (cantidades y montos acumulados)";
        _actions.Visible = true;
        _search.Visible = false;
        _addProductButton.Visible = false;
        _editProductButton.Visible = false;
        _stockCriticalLabel.Visible = false;
        SetReportControlsVisible(true);
        FilterSalesReport();
    }

    private void SetReportControlsVisible(bool visible)
    {
        _fromLabel.Visible = visible;
        _fromDate.Visible = visible;
        _toLabel.Visible = visible;
        _toDate.Visible = visible;
        _filterSalesButton.Visible = visible;
        _exportCsvButton.Visible = visible;
        _exportExcelButton.Visible = visible;
        _exportPdfButton.Visible = visible;
    }

    private void FilterSalesReport()
    {
        if (_fromDate.Value.Date > _toDate.Value.Date)
        {
            MessageBox.Show("La fecha inicial no puede ser posterior a la fecha final.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _currentReport = _sales.GetSalesReport(_fromDate.Value.Date, _toDate.Value.Date);
            _grid.DataSource = _currentReport.ToList();
        }
        catch (Exception exception)
        {
            ShowError("No se pudo generar el reporte", exception);
        }
    }

    private void ExportReport(string format, string extension, string filter, Action<string> export)
    {
        using var dialog = new SaveFileDialog
        {
            AddExtension = true,
            DefaultExt = extension.TrimStart('.'),
            FileName = $"ReporteVentas_{DateTime.Now:yyyyMMdd}{extension}",
            Filter = filter,
            Title = $"Exportar reporte a {format}"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            export(dialog.FileName);
            MessageBox.Show($"El reporte se exportó correctamente a {format}.", "Exportación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            ShowError($"No se pudo exportar el reporte a {format}", exception);
        }
    }

    private void RegisterSale()
    {
        try
        {
            var products = _products.GetAll().Where(p => p.Stock > 0).OrderBy(p => p.Name).ToList();
            if (products.Count == 0)
            {
                MessageBox.Show("No hay productos con existencias disponibles.", "Registrar venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using var form = new SaleForm(products);
            if (form.ShowDialog(this) != DialogResult.OK) return;
            _sales.RegisterSale(_employee.EmployeeId, form.SelectedProduct.ProductId, form.Quantity);
            MessageBox.Show("La venta se registró y el inventario fue actualizado.", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowProducts(false);
        }
        catch (Exception exception)
        {
            ShowError("No se pudo registrar la venta", exception);
        }
    }

    private void AddEmployee()
    {
        using var form = new EmployeeForm();
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            _employees.Insert(form.Employee);
            ShowEmployees();
        }
        catch (Exception exception)
        {
            ShowError("No se pudo guardar el empleado. Verifique que el nombre de usuario no esté registrado", exception);
        }
    }

    private void EditEmployee()
    {
        if (_grid.CurrentRow?.DataBoundItem is not EmployeeListRow row)
        {
            MessageBox.Show("Seleccione un empleado para editar.", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var selected = _loadedEmployees.FirstOrDefault(employee => employee.EmployeeId == row.EmployeeId);
        if (selected is null)
        {
            ShowEmployees();
            return;
        }

        using var form = new EmployeeForm(selected, selected.EmployeeId == _employee.EmployeeId);
        if (form.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            var isRemovingActiveAdmin = selected.IsActive
                && selected.IsAdministrator
                && (!form.Employee.IsActive || !form.Employee.IsAdministrator);
            if (isRemovingActiveAdmin && _loadedEmployees.Count(employee => employee.IsActive && employee.IsAdministrator) <= 1)
            {
                MessageBox.Show("Debe quedar al menos un administrador activo en el sistema.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (form.Employee.PasswordHash.Length == 0)
                form.Employee.PasswordHash = selected.PasswordHash;
            _employees.Update(form.Employee);
            ShowEmployees();
        }
        catch (Exception exception)
        {
            ShowError("No se pudo actualizar el empleado. Verifique que el nombre de usuario no esté registrado", exception);
        }
    }

    private void AddProduct()
    {
        using var form = new ProductForm();
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            _products.Insert(form.Product);
            ShowProducts(false);
        }
        catch (Exception exception)
        {
            ShowError("No se pudo guardar el producto", exception);
        }
    }

    private void EditProduct()
    {
        if (_grid.CurrentRow?.DataBoundItem is not Product selected)
        {
            MessageBox.Show("Seleccione un producto para editar.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var form = new ProductForm(selected);
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            _products.Update(form.Product);
            ShowProducts(false);
        }
        catch (Exception exception)
        {
            ShowError("No se pudo actualizar el producto", exception);
        }
    }

    private void ApplyCircularAvatarMask()
    {
        if (_userIcon.Width <= 0 || _userIcon.Height <= 0) return;

        using var path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddEllipse(0, 0, _userIcon.Width, _userIcon.Height);
        _userIcon.Region?.Dispose();
        _userIcon.Region = new Region(path);
    }

    private static void ShowError(string message, Exception exception) =>
        MessageBox.Show($"{message}.\n\n{exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
