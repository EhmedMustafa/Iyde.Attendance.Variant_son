using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IAttendanceEarlyAttemptRepository
{
    Task AddAsync(AttendanceEarlyAttempt attendanceEarly);

    Task<List<AttendanceEarlyAttempt>> GetByDateAsync(DateTime? date);
    Task SaveAsync();

}


