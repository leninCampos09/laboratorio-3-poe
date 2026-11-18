using laboratorio_3_poe.Models;
using laboratorio_3_poe.Services;

namespace laboratorio_3_poe.Forms;

public sealed partial class EmployeeForm : Form
{
    private readonly Employee? _original;

    public Employee Employee { get; private set; } = new();

    public EmployeeForm() : this(null)
    {
    }

    public EmployeeForm(Employee? employee) : this(employee, false)
    {
    }

    public EmployeeForm(Employee? employee, bool isCurrentEmployee)
    {
        InitializeComponent();
        _original = employee;
        Text = employee is null ? "Nuevo empleado" : "Editar empleado";
        _role.Items.AddRange(["Empleado", "Administrador"]);
        _fullName.Text = employee?.FullName ?? "";
        _username.Text = employee?.Username ?? "";
        _role.SelectedItem = employee?.Role ?? "Empleado";
        _active.Checked = employee?.IsActive ?? true;
        _role.Enabled = !isCurrentEmployee;
        _active.Enabled = !isCurrentEmployee;
        _passwordLabel.Text = employee is null ? "Contraseña:" : "Nueva contraseña:";
        _password.PlaceholderText = employee is null ? "Obligatoria, mínimo 8 caracteres" : "Dejar vacía para conservar la actual";
        _showPassword.CheckedChanged += (_, _) => _password.UseSystemPasswordChar = !_showPassword.Checked;
        _save.Click += (_, _) => SaveEmployee();
    }

    private void SaveEmployee()
    {
        if (string.IsNullOrWhiteSpace(_fullName.Text) || string.IsNullOrWhiteSpace(_username.Text))
        {
            MessageBox.Show("El nombre completo y el usuario son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_original is null && _password.Text.Length < 8)
        {
            MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_password.Text.Length > 0 && _password.Text.Length < 8)
        {
            MessageBox.Show("La nueva contraseña debe tener al menos 8 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Employee = new Employee
        {
            EmployeeId = _original?.EmployeeId ?? 0,
            FullName = _fullName.Text.Trim(),
            Username = _username.Text.Trim(),
            Role = _role.SelectedItem?.ToString() ?? "Empleado",
            IsActive = _active.Checked,
            PasswordHash = string.IsNullOrEmpty(_password.Text)
                ? []
                : PasswordHasher.Hash(_password.Text)
        };
        DialogResult = DialogResult.OK;
        Close();
    }
}
