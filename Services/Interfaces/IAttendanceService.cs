using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IAttendanceService
{
    Task<ResultDto> CheckInAsync(int employeeId, int storeId);
    Task<ResultDto> CheckOutAsync(int employeeId);
}