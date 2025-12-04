using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;
    public AttendanceController(IAttendanceService attendanceService) => _attendanceService = attendanceService;

    [HttpPost("checkin")]
    public async Task<IActionResult> CheckIn(CheckInDto dto)
        => Ok(await _attendanceService.CheckInAsync(dto.EmployeeId, dto.StoreId));

    [HttpPost("checkout")]
    public async Task<IActionResult> CheckOut(CheckOutDto dto)
        => Ok(await _attendanceService.CheckOutAsync(dto.EmployeeId));
}