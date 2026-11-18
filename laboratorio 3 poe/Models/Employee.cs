using RepoDb.Attributes;

namespace laboratorio_3_poe.Models;

[Map("Employees")]
public sealed class Employee
{
    [Primary, Identity]
    public int EmployeeId { get; set; }
    public string Username { get; set; } = "";
    public byte[] PasswordHash { get; set; } = [];
    public string FullName { get; set; } = "";
    public bool IsActive { get; set; }
    public string Role { get; set; } = "Empleado";
    public bool IsAdministrator =>
        string.Equals(Role, "Administrador", StringComparison.OrdinalIgnoreCase)
        || string.Equals(Username, "admin", StringComparison.OrdinalIgnoreCase);
}
