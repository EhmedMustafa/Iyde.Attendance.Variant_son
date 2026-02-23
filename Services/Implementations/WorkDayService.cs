using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Iyde.Attendance.Variant3.Services.Implementations
{
    public class WorkDayService : IWorkDayService
    {

        private readonly IWorkDayRepository _workDayRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IStoreRepository _storeRepository;

        public WorkDayService(IWorkDayRepository workDayRepository,IEmployeeRepository employeeRepository,IAttendanceRepository attendanceRepository,IStoreRepository storeRepository)
        {
            _workDayRepository = workDayRepository;
            _employeeRepository = employeeRepository;
            _attendanceRepository = attendanceRepository;
            _storeRepository = storeRepository;
        }

     

        public async Task<List<MonthlyEmployeeSummaryDto>> GetMonthlySummary(int year, int month)
        {
            var result= new List<MonthlyEmployeeSummaryDto>();

            var today= DateOnly.FromDateTime(DateTime.Now);

            var startDate = new DateOnly(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            if (endDate > today)
            {
                endDate = today;
            }

            var employees= await _employeeRepository.GetAllAsync();
            var allWorkDays = await _workDayRepository.GetByDateRangeAsync(startDate, endDate);
            var allAttendances = await _attendanceRepository.GetByDateRangeAsync(startDate, endDate);

            var workDaysDict = allWorkDays
                .GroupBy(wd => wd.EmployeeId)
                .ToDictionary(g => g.Key, g => g.ToList());

            var attendancesDict = allAttendances
                .GroupBy(at => at.EmployeeId)
                .ToDictionary(g => g.Key, g => g.ToList());


            foreach (var emp in employees) 
            {
                //var stores = await _storeRepository.GetAllAsync();

                int absent= 0;
                int late = 0;
                int early = 0;


                if (!workDaysDict.TryGetValue(emp.Id, out var empWorksDay)) 
                {
                    empWorksDay = new List<WorkDay>();
                }

                if (!attendancesDict.TryGetValue(emp.Id, out var empAttandanse))
                {
                    empAttandanse = new List<Attendances>();
                }


               // var workDays = await _workDayRepository.GetByEmployeeAndMonthAsync(emp.Id,year, month);

                foreach (var wd in empWorksDay)
                {
                   // var att =await _attendanceRepository.GetByEmployeeAndDateAsync(emp.Id, wd.Date);

                    var att= empAttandanse
                        .FirstOrDefault(a => DateOnly.FromDateTime(a.CheckIn) == wd.Date);

                    if (!wd.IsDayOff && att == null)
                    {
                        absent++;
                        continue;
                    }

                    if(att==null) continue;

                    if(wd.PlannedStart==null||wd.PlannedEnd==null) continue;

                    var plstart = wd.Date.ToDateTime(wd.PlannedStart.Value);
                    var plend = wd.Date.ToDateTime(wd.PlannedEnd.Value);

                    if (att.CheckIn > plstart)
                    {
                        late+= (int)(att.CheckIn - plstart).TotalMinutes;
                    }

                    if (att.CheckOut.HasValue&& att.CheckOut < plend) 
                    {
                        early += (int)(plend - att.CheckOut.Value).TotalMinutes;
                    }
                }

                result.Add(new MonthlyEmployeeSummaryDto
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.FullName,
                    StoreName = emp.Store.Name,
                    AbsentDays = absent,
                    TotalLateMinitus = late,
                    TotalEarlyLeaveMinutes = early
                });
            }

            return result;
        }

        public async Task<bool> UpdateWorkDayAsync(UpdateWorkDayDto dto)
        {
            var existing = await _workDayRepository.GetByEmployeeAndDateAsync(dto.EmployeeId,dto.Date);

            if (existing == null)
            {
                return false;
            }

            existing.StoreId = dto.StoreId;
            existing.PlannedStart = dto.PlannedStart;
            existing.PlannedEnd = dto.PlannedEnd;
            existing.IsDayOff = dto.IsDayOff;

            existing.UpdatedBy = dto.ModifiedByUser;
            existing.UpdatedAt = DateTime.Now;

            

            await _workDayRepository.SaveAsync();

            return true;
        }
    }
}
