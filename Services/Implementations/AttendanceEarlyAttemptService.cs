using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations
{
    public class AttendanceEarlyAttemptService : IAttendanceEarlyAttemptService
    {
        private readonly IAttendanceEarlyAttemptRepository _attendanceEarlyAttemptRepository;
        public AttendanceEarlyAttemptService(IAttendanceEarlyAttemptRepository attendanceEarlyAttemptRepository)
        {
            _attendanceEarlyAttemptRepository = attendanceEarlyAttemptRepository;
        }

        public async Task<List<AttendanceEarlyAttemptDto>> GetEarlyAttemptsAsync(DateTime? date)
        {
            var targetDate = date?.Date ?? DateTime.Today;

            var list = await _attendanceEarlyAttemptRepository.GetByDateAsync(targetDate);

            return list.Select(x => new AttendanceEarlyAttemptDto
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.Employee.FullName,
                StoreName = x.Store.Name,
                AttemptTime = x.AttemptTime,
                Reason = x.Reason,
                Source = x.Source
            }).ToList();
        }

        public async Task LogEarlyAttemptAsync(int employeeId, int storeId, string reason, string source)
        {
            var attempt = new AttendanceEarlyAttempt
            {
                EmployeeId = employeeId,
                StoreId = storeId,
                AttemptTime = DateTime.Now,
                Reason = reason,
                Source = source
            };

            await _attendanceEarlyAttemptRepository.AddAsync(attempt);
        }
    }
}
