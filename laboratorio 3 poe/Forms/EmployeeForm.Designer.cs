namespace laboratorio_3_poe.Forms;

partial class EmployeeForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel _layout = null!;
    private Label _fullNameLabel = null!;
    private TextBox _fullName = null!;
    private Label _usernameLabel = null!;
    private TextBox _username = null!;
    private Label _passwordLabel = null!;
    private TextBox _password = null!;
    private CheckBox _showPassword = null!;
    private Label _roleLabel = null!;
    private ComboBox _role = null!;
    private CheckBox _active = null!;
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
        _fullNameLabel = new Label();
        _fullName = new TextBox();
        _usernameLabel = new Label();
        _username = new TextBox();
        _passwordLabel = new Label();
        _password = new TextBox();
        _showPassword = new CheckBox();
        _roleLabel = new Label();
        _role = new ComboBox();
        _active = new CheckBox();
        _save = new Button();
        _layout.SuspendLayout();
        SuspendLayout();
        // 
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_fullNameLabel, 0, 0);
        _layout.Controls.Add(_fullName, 1, 0);
        _layout.Controls.Add(_usernameLabel, 0, 1);
        _layout.Controls.Add(_username, 1, 1);
        _layout.Controls.Add(_passwordLabel, 0, 2);
        _layout.Controls.Add(_password, 1, 2);
        _layout.Controls.Add(_showPassword, 1, 3);
        _layout.Controls.Add(_roleLabel, 0, 4);
        _layout.Controls.Add(_role, 1, 4);
        _layout.Controls.Add(_active, 1, 5);
        _layout.Controls.Add(_save, 1, 6);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 0);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(22);
        _layout.RowCount = 7;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.Size = new Size(520, 390);
        _layout.TabIndex = 0;
        // 
        // _fullNameLabel
        // 
        _fullNameLabel.Dock = DockStyle.Fill;
        _fullNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _fullNameLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _fullNameLabel.Location = new Point(25, 22);
        _fullNameLabel.Name = "_fullNameLabel";
        _fullNameLabel.Size = new Size(139, 48);
        _fullNameLabel.TabIndex = 0;
        _fullNameLabel.Text = "Nombre completo:";
        _fullNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _fullName
        // 
        _fullName.Dock = DockStyle.Fill;
        _fullName.Location = new Point(170, 25);
        _fullName.Name = "_fullName";
        _fullName.Size = new Size(325, 23);
        _fullName.TabIndex = 1;
        // 
        // _usernameLabel
        // 
        _usernameLabel.Dock = DockStyle.Fill;
        _usernameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _usernameLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _usernameLabel.Location = new Point(25, 70);
        _usernameLabel.Name = "_usernameLabel";
        _usernameLabel.Size = new Size(139, 48);
        _usernameLabel.TabIndex = 2;
        _usernameLabel.Text = "Usuario:";
        _usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _username
        // 
        _username.Dock = DockStyle.Fill;
        _username.Location = new Point(170, 73);
        _username.Name = "_username";
        _username.Size = new Size(325, 23);
        _username.TabIndex = 3;
        // 
        // _passwordLabel
        // 
        _passwordLabel.Dock = DockStyle.Fill;
        _passwordLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _passwordLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _passwordLabel.Location = new Point(25, 118);
        _passwordLabel.Name = "_passwordLabel";
        _passwordLabel.Size = new Size(139, 48);
        _passwordLabel.TabIndex = 4;
        _passwordLabel.Text = "Contraseña:";
        _passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _password
        // 
        _password.Dock = DockStyle.Fill;
        _password.Location = new Point(170, 121);
        _password.Name = "_password";
        _password.Size = new Size(325, 23);
        _password.TabIndex = 5;
        _password.UseSystemPasswordChar = true;
        // 
        // _showPassword
        // 
        _showPassword.AutoSize = true;
        _showPassword.Location = new Point(170, 169);
        _showPassword.Name = "_showPassword";
        _showPassword.Size = new Size(128, 19);
        _showPassword.TabIndex = 6;
        _showPassword.Text = "Mostrar contraseña";
        // 
        // _roleLabel
        // 
        _roleLabel.Dock = DockStyle.Fill;
        _roleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _roleLabel.ForeColor = Color.FromArgb(45, 55, 72);
        _roleLabel.Location = new Point(25, 198);
        _roleLabel.Name = "_roleLabel";
        _roleLabel.Size = new Size(139, 48);
        _roleLabel.TabIndex = 7;
        _roleLabel.Text = "Rol:";
        _roleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _role
        // 
        _role.Dock = DockStyle.Fill;
        _role.DropDownStyle = ComboBoxStyle.DropDownList;
        _role.Location = new Point(170, 201);
        _role.Name = "_role";
        _role.Size = new Size(325, 23);
        _role.TabIndex = 8;
        // 
        // _active
        // 
        _active.AutoSize = true;
        _active.Location = new Point(170, 249);
        _active.Name = "_active";
        _active.Size = new Size(114, 19);
        _active.TabIndex = 9;
        _active.Text = "Empleado activo";
        // 
        // _save
        // 
        _save.Anchor = AnchorStyles.Right;
        _save.BackColor = Color.FromArgb(25, 135, 84);
        _save.Cursor = Cursors.Hand;
        _save.FlatAppearance.BorderSize = 0;
        _save.FlatStyle = FlatStyle.Flat;
        _save.ForeColor = Color.White;
        _save.Location = new Point(370, 309);
        _save.Name = "_save";
        _save.Size = new Size(125, 38);
        _save.TabIndex = 10;
        _save.Text = "Guardar";
        _save.UseVisualStyleBackColor = false;
        // 
        // EmployeeForm
        // 
        AcceptButton = _save;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(520, 390);
        Controls.Add(_layout);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EmployeeForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Empleado";
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        ResumeLayout(false);
    }

    private static void ConfigureLabel(Label label, string text)
    {
        label.Anchor = AnchorStyles.Left;
        label.AutoSize = true;
        label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label.ForeColor = Color.FromArgb(45, 55, 72);
        label.Text = text;
    }
}
