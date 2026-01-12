using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces;

public interface IWorkDayRepository
{
    Task<WorkDay> GetByEmployeeAndDateAsync(int employeeId, DateOnly date);
    Task<List<WorkDay>> GetByDateAsync(DateOnly date);
    Task AddAsync(WorkDay workDay);

    Task<List<WorkDay>> GetByEmployeeAndMonthAsync(int employeeId,int year,int month);
    Task SaveAsync();
}