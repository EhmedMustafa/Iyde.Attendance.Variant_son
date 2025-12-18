using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly ApplicationDbContext _context;
    public AttendanceRepository(ApplicationDbContext context) => _context = context;

    public Task<Attendances?> GetOpenForTodayAsync(int employeeId,DateOnly date)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _context.Attendances
            .Where(a => a.EmployeeId == employeeId &&
                        DateOnly.FromDateTime(a.CheckIn) == date)
           
            .FirstOrDefaultAsync();
    }

    public Task<Attendances?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date)
    {
        return _context.Attendances
            .Where(a => a.EmployeeId == employeeId &&
                        DateOnly.FromDateTime(a.CheckIn) == date)
            .OrderByDescending(a => a.CheckIn)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Attendances attendance)
        => await _context.Attendances.AddAsync(attendance);

    public Task SaveAsync() => _context.SaveChangesAsync();
}