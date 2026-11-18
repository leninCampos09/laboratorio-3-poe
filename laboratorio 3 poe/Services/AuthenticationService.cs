using laboratorio_3_poe.Data;
using laboratorio_3_poe.Models;

namespace laboratorio_3_poe.Services;

public sealed class AuthenticationService
{
    private readonly IRepository<Employee> _employees = new RepoDbRepository<Employee>();

    public Employee? Authenticate(string username, string password)
    {
        var employee = _employees.Find(new { Username = username.Trim() });
        return employee is { IsActive: true } && PasswordHasher.Verify(password, employee.PasswordHash)
            ? employee
            : null;
    }
}
