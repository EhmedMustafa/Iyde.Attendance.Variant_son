using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IAttendanceRepository
{
    Task<Attendances?> GetOpenForTodayAsync(int employeeId, DateOnly date);
    Task<Attendances?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date);
    Task<List<Attendances>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate);
    Task AddAsync(Attendances attendance);
    Task SaveAsync();
}