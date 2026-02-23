using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IStoreRepository
{

    Task<List<Store>> GetAllAsync();
    Task<Store?> GetByIdAsync(int id);
    Task AddAsync(Store store);
    Task SaveAsync();

    Task<List<Store>> GetStoresByCompanyIdAsync(int? companyId);
}