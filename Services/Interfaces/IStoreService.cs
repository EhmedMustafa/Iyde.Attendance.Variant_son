using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IStoreService
{
    Task<ResultDto> CreateAsync(string name);
}