using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IStoreService
{
    Task<List<GetAllStoreDto>> GetAllAsync();
    Task<ResultDto> CreateAsync(string name);
}