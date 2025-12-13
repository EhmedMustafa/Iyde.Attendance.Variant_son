using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations;

public class EmployeeService : Interfaces.IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

    public async Task<ResultDto> CreateAsync(string fullName,int StoreId)
    {
        var emp = new Employee
        {
            FullName = fullName,
            StoreId= StoreId,
            PersonalQr = Guid.NewGuid().ToString()
        };
        await _employeeRepository.AddAsync(emp);
        await _employeeRepository.SaveAsync();
        return ResultDto.Ok("Employee created");
    }
}