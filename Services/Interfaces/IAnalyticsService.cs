using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IAnalyticsService
{
    Task<DailyReportDto> GetDailyReportAsync(DateOnly date);
}