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

    public Task<Employee> GetWithStoreAsync(int id)
    
        => _context.Employees
            .Include(e => e.Store)
            .FirstAsync(e => e.Id == id);

    public async Task AutoClocedPreviusOpenAsync(int Id)
    {
        var yestarday = DateTime.Today.AddDays(-1);

        var open= await _context.Attendances
            .Where(a=>a.EmployeeId==Id&&
                   a.CheckOut==null&&
                   a.CheckIn.Date<=yestarday.Date).FirstOrDefaultAsync();

        if (open != null) 
        {
            open.CheckOut= open.CheckIn.Date.AddDays(1).AddSeconds(-1);
            open.IsAutoCloced = true;
            await _context.SaveChangesAsync();
        }


    }
}