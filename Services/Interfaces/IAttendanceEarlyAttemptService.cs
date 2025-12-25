using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces
{
    public interface IAttendanceEarlyAttemptService
    {
        Task LogEarlyAttemptAsync(
        int employeeId,
        int storeId,
        string reason,
        string source);

        Task<List<AttendanceEarlyAttemptDto>> GetEarlyAttemptsAsync(
       DateTime? date);
    }
}
