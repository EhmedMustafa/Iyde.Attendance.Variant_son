using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Services.Interfaces;

public interface IStoreService
{
    Task<List<GetAllStoreDto>> GetAllAsync();
    Task<ResultDto> CreateAsync(string name,int? id);

    Task<List<GetAllStoreDto>> GetStoresByCompanyIdAsync(int? companyId);
}