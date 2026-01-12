using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IEmployeeRepository
{

    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task<Employee> GetWithStoreAsync(int id);

    Task AutoClocedPreviusOpenAsync(int Id);
    Task SaveAsync();
}