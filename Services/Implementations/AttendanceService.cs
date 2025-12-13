using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IEmployeeRepository _employeeRepository;

    //public AttendanceService(IAttendanceRepository attendanceRepository)
    //{
    //    _attendanceRepository = attendanceRepository;
    //}

    public AttendanceService(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        _attendanceRepository = attendanceRepository;
    }

    public async Task<ResultDto> CheckInAsync(int employeeId, int storeId)
    {

        var emp= await _employeeRepository.GetByIdAsync(employeeId);
        if (emp == null)
        {
            return ResultDto.Fail("❌ Belə işçi mövcud deyil.");
        }

        if (emp.StoreId != storeId) 
        {
            return ResultDto.Fail("❌ İşçi yalnız öz mağazasında giriş edə bilər.");
        }
       



        var open = await _attendanceRepository.GetOpenForTodayAsync(employeeId);
        if (open != null)
            return ResultDto.Fail("Bu gün üçün aktiv giriş artıq mövcuddur.");

       
        var att = new Attendances
        {
            EmployeeId = employeeId,
            StoreId = storeId,
            CheckIn = DateTime.Now
        };

        await _attendanceRepository.AddAsync(att);
        await _attendanceRepository.SaveAsync();
        return ResultDto.Ok("Giriş qeydə alındı.");
    }

    public async Task<ResultDto> CheckOutAsync(int employeeId)
    {
        var open = await _attendanceRepository.GetOpenForTodayAsync(employeeId);
        if (open is null)
            return ResultDto.Fail("Bu gün üçün açıq giriş tapılmadı.");

        open.CheckOut = DateTime.Now;
        await _attendanceRepository.SaveAsync();
        return ResultDto.Ok("Çıxış qeydə alındı.");
    }
}