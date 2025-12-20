using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Repositories.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations;

public class AnalyticsService : Interfaces.IAnalyticsService
{
    private readonly IWorkDayRepository _workDayRepository;
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IStoreRepository _storeRepository;

    public AnalyticsService(
        IWorkDayRepository workDayRepository,
        IAttendanceRepository attendanceRepository,
        IEmployeeRepository employeeRepository,
        IStoreRepository storeRepository)
    {
        _workDayRepository = workDayRepository;
        _attendanceRepository = attendanceRepository;
        _employeeRepository = employeeRepository;
        _storeRepository = storeRepository;
    }

    public async Task<DailyReportDto> GetDailyReportAsync(DateOnly date)
    {
        var workDays = await _workDayRepository.GetByDateAsync(date);
        var report = new DailyReportDto { Date = date };

        foreach (var wd in workDays)
        {
            var att = await _attendanceRepository.GetByEmployeeAndDateAsync(wd.EmployeeId, date);
            wd.PlannedStart = wd.PlannedStart;
            wd.PlannedEnd = wd.PlannedEnd;

            if (att != null)
            {
                att.CheckIn = att.CheckIn;
                att.CheckOut = att.CheckOut;
            }
            var emp = await _employeeRepository.GetByIdAsync(wd.EmployeeId);
            var store = await _storeRepository.GetByIdAsync(wd.StoreId);

            var item = new EmployeeDayStatusDto
            {
                
                EmployeeId = wd.EmployeeId,
                EmployeeName = emp?.FullName ?? wd.EmployeeId.ToString(),
                StoreName = store?.Name ?? wd.StoreId.ToString(),
                Date = date,
                PlannedRange = wd.IsDayOff
                    ? "İstirahət"
                    : $"{wd.PlannedStart:HH\\:mm} - {wd.PlannedEnd:HH\\:mm}",
                PlannedStart = wd.PlannedStart,
                PlannedEnd = wd.PlannedEnd,
               
                CheckIn = att?.CheckIn,
                CheckOut = att?.CheckOut,
                IsAutoCloced = att?.IsAutoCloced ?? false
            };
            if (wd.IsDayOff)
            {
                item.Status = "İstirahət";
            }
            else if (att is null)
            {
                item.Status = "Gəlməyib";
            }
            else
            {
                var plannedStart = date.ToDateTime(wd.PlannedStart);
                var plannedEnd = date.ToDateTime(wd.PlannedEnd);
                var end = att.CheckOut ?? att.CheckIn;
                item.WorkedMinutes = (int)(end - att.CheckIn).TotalMinutes;

                item.PlannedStart = wd.IsDayOff ? null : wd.PlannedStart;
                item.PlannedEnd = wd.IsDayOff ? null : wd.PlannedEnd;

                item.PlannedRange = wd.IsDayOff
                ? "İstirahət"
                : $"{wd.PlannedStart:HH\\:mm} - {wd.PlannedEnd:HH\\:mm}";

                if (att.CheckIn > plannedStart)
                    item.MinutesLate = (int)(att.CheckIn - plannedStart).TotalMinutes;

                if (att.CheckOut.HasValue && att.CheckOut.Value < plannedEnd)
                    item.MinutesEarlyLeave = (int)(plannedEnd - att.CheckOut.Value).TotalMinutes;

                if (item.MinutesLate > 0 && item.MinutesEarlyLeave > 0)
                    item.Status = "Gec gəlib,Tez çıxıb";
                else if (item.MinutesLate > 0)
                    item.Status = "Gec gəlib";
                else if (item.MinutesEarlyLeave > 0)
                    item.Status = "Tez çıxıb";
                else
                    item.Status = "Tam";
            }

            report.Items.Add(item);
        }

        return report;
    }
}