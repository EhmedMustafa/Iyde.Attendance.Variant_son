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



    [HttpPut("update-workday")]
    public async Task<IActionResult> Update( [FromBody] CreateWorkDayDto dto)
    {

        //var currentdate = DateOnly.FromDateTime(DateTime.Now);
        var existingWorkDay = await _workDayRepository.GetByEmployeeAndDateAsync(dto.EmployeeId, dto.Date);
        if (existingWorkDay == null)
        {
            return NotFound("Work day not found.");
        }


        existingWorkDay.StoreId = dto.StoreId;
        existingWorkDay.PlannedStart = dto.PlannedStart;
        existingWorkDay.PlannedEnd = dto.PlannedEnd;
        existingWorkDay.IsDayOff = dto.IsDayOff;
        await _workDayRepository.SaveAsync();
        return Ok();
    }
}