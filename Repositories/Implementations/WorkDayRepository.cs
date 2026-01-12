using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations;

public class WorkDayRepository : IWorkDayRepository
{
    private readonly ApplicationDbContext _context;
    public WorkDayRepository(ApplicationDbContext context) => _context = context;

    public Task<WorkDay> GetByEmployeeAndDateAsync(int employeeId, DateOnly date)
        => _context.WorkDays.FirstOrDefaultAsync(w => w.EmployeeId == employeeId && w.Date == date);

    public Task<List<WorkDay>> GetByDateAsync(DateOnly date)
        => _context.WorkDays
            .Where(w => w.Date == date)
            .ToListAsync();

    public async Task AddAsync(WorkDay workDay)
        => await _context.WorkDays.AddAsync(workDay);

    public Task SaveAsync() => _context.SaveChangesAsync();

    public Task<List<WorkDay>> GetByEmployeeAndMonthAsync(int employeeId, int year, int month)
    {
        return _context.WorkDays
            .Where(w => w.EmployeeId == employeeId &&
                        w.Date.Year == year &&
                        w.Date.Month == month)
            .ToListAsync();
    }
}