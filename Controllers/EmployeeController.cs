using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeController(IEmployeeService employeeService,IEmployeeRepository employeeRepository)
    {
        _employeeService = employeeService;
        _employeeRepository = employeeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
        => Ok(await _employeeService.CreateAsync(dto.FullName,dto.StoreId));

    [HttpGet("{employeeId}/summary")]
    public async Task<IActionResult> GetEmployeeSummary(int employeeId) 
    {
        var emp= await _employeeRepository.GetWithStoreAsync(employeeId);
        if (emp == null)
            return NotFound();

        return Ok(new
        {
            employeeName = emp.FullName,
            storeName = emp.Store.Name,
        });
    }
    

}