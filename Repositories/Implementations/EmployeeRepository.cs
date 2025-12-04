using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    public EmployeeRepository(ApplicationDbContext context) => _context = context;

    public Task<Employee?> GetByIdAsync(int id)
        => _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

    public async Task AddAsync(Employee employee)
        => await _context.Employees.AddAsync(employee);

    public Task SaveAsync() => _context.SaveChangesAsync();
}