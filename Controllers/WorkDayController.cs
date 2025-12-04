using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkDayController : ControllerBase
{
    private readonly IWorkDayRepository _workDayRepository;
    public WorkDayController(IWorkDayRepository workDayRepository) => _workDayRepository = workDayRepository;

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkDayDto dto)
    {
        var wd = new WorkDay
        {
            EmployeeId = dto.EmployeeId,
            StoreId = dto.StoreId,
            Date = dto.Date,
            PlannedStart = dto.PlannedStart,
            PlannedEnd = dto.PlannedEnd,
            IsDayOff = dto.IsDayOff
        };
        await _workDayRepository.AddAsync(wd);
        await _workDayRepository.SaveAsync();
        return Ok();
    }
}