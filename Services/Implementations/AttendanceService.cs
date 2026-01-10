using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWorkDayRepository _workDayRepository;
    private readonly IAttendanceEarlyAttemptRepository _attendanceEarly;


    //public AttendanceService(IAttendanceRepository attendanceRepository)
    //{
    //    _attendanceRepository = attendanceRepository;
    //}

    public AttendanceService(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository, IWorkDayRepository workDayRepository,IAttendanceEarlyAttemptRepository attendanceEarly)
    {
        _employeeRepository = employeeRepository;
        _attendanceRepository = attendanceRepository;
        _workDayRepository = workDayRepository;
        _attendanceEarly = attendanceEarly;

    }

    public async Task<ResultDto> CheckInAsync(int employeeId, int storeId)
    {
        var now = DateTime.Now.TimeOfDay;
        var allowedStart = new TimeSpan(7, 0 ,0); // 8:00 AM

        if (now < allowedStart)
        {

            var earlyAttempt = new AttendanceEarlyAttempt
            {
                EmployeeId = employeeId,
                StoreId = storeId,
                AttemptTime = DateTime.Now,
                Reason = "Erkən giriş cəhdi",
                Source = "Bot"
            };

            await _attendanceEarly.AddAsync(earlyAttempt);
            await _attendanceEarly.SaveAsync();

            return ResultDto.Fail("❌ Giriş yalnız saat 07:00-dan sonra mümkündür.");
        }




        var daywork = await _workDayRepository.GetByEmployeeAndDateAsync(employeeId, DateOnly.FromDateTime(DateTime.Now));

        if (daywork == null)
        {
            return ResultDto.Fail("❌ Bu gün üçün iş günü təyin edilməyib.");
        }

        if (daywork.IsDayOff)
        {
            return ResultDto.Fail("❌ Bu gün sizin istirahət gününüzdür.");
        }


        await _employeeRepository.AutoClocedPreviusOpenAsync(employeeId);



        var emp= await _employeeRepository.GetByIdAsync(employeeId);
        if (emp == null)
        {
            return ResultDto.Fail("❌ Belə işçi mövcud deyil.");
        }

        if (emp.StoreId != storeId) 
        {
            return ResultDto.Fail("❌ İşçi yalnız öz mağazasında giriş edə bilər.");
        }
       


        var today= DateOnly.FromDateTime(DateTime.Now);
        var open = await _attendanceRepository.GetOpenForTodayAsync(employeeId,today);

        if (open != null) 
        {
            return new ResultDto
            {
                Success = false,
                Message = "❌ Siz bu gün artıq giriş etmisiniz.",
                CheckInTime = open.CheckIn,
            };
        }
            //return new ResultDto.Fail("Bu gün üçün aktiv giriş artıq mövcuddur.");

       
        var att = new Attendances
        {
            EmployeeId = employeeId,
            StoreId = storeId,
            CheckIn = DateTime.Now  
        };

        await _attendanceRepository.AddAsync(att);
        await _attendanceRepository.SaveAsync();

        return new ResultDto
        {
            WasAutoClosed = att.IsAutoCloced,
            Success = true,
            Message = "✅ Giriş qeydə alındı.",
            CheckInTime = att.CheckIn
        };
        //return ResultDto.Ok("Giriş qeydə alındı.");
    }

    public async Task<ResultDto> CheckOutAsync(int employeeId)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var open = await _attendanceRepository.GetOpenForTodayAsync(employeeId,today);



        if (open is null)
            return ResultDto.Fail("Bu gün üçün açıq giriş tapılmadı.");

        if (open.CheckOut != null) 
        {
            return new ResultDto
            {
                Success = false,
                Message = "❌ Siz bu gün artıq çıxış etmisiniz.",
                CheckOutTime = open.CheckOut
            };
        }


        open.CheckOut = DateTime.Now;

       
        await _attendanceRepository.SaveAsync();

        return new ResultDto
        {
            Success = true,
            Message = "✅ Çıxış qeydə alındı.",
            CheckOutTime = open.CheckOut
        };
        //return ResultDto.Ok("Çıxış qeydə alındı.");
    }
}