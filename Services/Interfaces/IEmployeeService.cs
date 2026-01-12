using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IEmployeeService
{
    
    Task<ResultDto> CreateAsync(string fullName,int StoreId);

}