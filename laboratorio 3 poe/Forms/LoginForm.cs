using laboratorio_3_poe.Models;
using laboratorio_3_poe.Services;

namespace laboratorio_3_poe.Forms;

public sealed partial class LoginForm : Form
{
    private readonly AuthenticationService _authentication = new();

    public LoginForm()
    {
        InitializeComponent();
        _signIn.Click += SignIn;
        _showPassword.CheckedChanged += (_, _) => _password.UseSystemPasswordChar = !_showPassword.Checked;
    }

    private void SignIn(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_username.Text) || string.IsNullOrEmpty(_password.Text))
        {
            MessageBox.Show("Ingrese usuario y contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            Employee? employee = _authentication.Authenticate(_username.Text, _password.Text);
            if (employee is null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Hide();
            using var main = new MainForm(employee);
            main.ShowDialog(this);
            _password.Clear();
            Show();
        }
        catch (Exception exception)
        {
            MessageBox.Show($"No se pudo iniciar sesión. Verifique la conexión y la base de datos.\n\n{exception.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
