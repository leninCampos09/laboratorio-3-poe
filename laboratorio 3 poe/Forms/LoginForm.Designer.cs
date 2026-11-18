namespace laboratorio_3_poe.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label _titleLabel = null!;
    private Label _usernameLabel = null!;
    private TextBox _username = null!;
    private Label _passwordLabel = null!;
    private TextBox _password = null!;
    private CheckBox _showPassword = null!;
    private Button _signIn = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _titleLabel = new Label();
        _usernameLabel = new Label();
        _username = new TextBox();
        _passwordLabel = new Label();
        _password = new TextBox();
        _showPassword = new CheckBox();
        _signIn = new Button();
        SuspendLayout();
        _titleLabel.AutoSize = true;
        _titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        _titleLabel.Location = new Point(75, 30);
        _titleLabel.Text = "Sistema de ventas";
        _usernameLabel.AutoSize = true;
        _usernameLabel.Location = new Point(55, 105);
        _usernameLabel.Text = "Usuario";
        _username.Font = new Font("Segoe UI", 11F);
        _username.Location = new Point(55, 128);
        _username.Size = new Size(310, 32);
        _passwordLabel.AutoSize = true;
        _passwordLabel.Location = new Point(55, 175);
        _passwordLabel.Text = "Contraseña";
        _password.Font = new Font("Segoe UI", 11F);
        _password.Location = new Point(55, 198);
        _password.Size = new Size(310, 32);
        _password.UseSystemPasswordChar = true;
        _showPassword.AutoSize = true;
        _showPassword.Location = new Point(55, 230);
        _showPassword.Text = "Mostrar contraseña";
        _signIn.BackColor = Color.FromArgb(31, 78, 121);
        _signIn.FlatStyle = FlatStyle.Flat;
        _signIn.ForeColor = Color.White;
        _signIn.Location = new Point(55, 260);
        _signIn.Size = new Size(310, 38);
        _signIn.Text = "Ingresar";
        _signIn.UseVisualStyleBackColor = false;
        AcceptButton = _signIn;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(420, 325);
        Controls.Add(_titleLabel);
        Controls.Add(_usernameLabel);
        Controls.Add(_username);
        Controls.Add(_passwordLabel);
        Controls.Add(_password);
        Controls.Add(_showPassword);
        Controls.Add(_signIn);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Iniciar sesión - Ventas Electrónica";
        ResumeLayout(false);
        PerformLayout();
    }
}
