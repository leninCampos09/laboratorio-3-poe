namespace laboratorio_3_poe.Models;

public sealed class EmployeeListRow
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; } = "";
    public string Username { get; set; } = "";
    public string Role { get; set; } = "";
    public string Status { get; set; } = "";
}
