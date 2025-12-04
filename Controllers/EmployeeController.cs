using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
        => Ok(await _employeeService.CreateAsync(dto.FullName));

  
    
}