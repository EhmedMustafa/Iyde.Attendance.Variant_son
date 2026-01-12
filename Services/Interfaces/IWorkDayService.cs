using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces
{
    public interface IWorkDayService
    {
        Task<List<MonthlyEmployeeSummaryDto>> GetMonthlySummary(int year, int month);
        
    }
}
