using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IAttendanceRepository
{
    Task<Attendances?> GetOpenForTodayAsync(int employeeId);
    Task<Attendances?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date);
    Task AddAsync(Attendances attendance);
    Task SaveAsync();
}