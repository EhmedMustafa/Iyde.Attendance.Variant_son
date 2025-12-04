using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _context;
    public StoreRepository(ApplicationDbContext context) => _context = context;

    public Task<Store?> GetByIdAsync(int id)
        => _context.Stores.FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddAsync(Store store)
        => await _context.Stores.AddAsync(store);

    public Task SaveAsync() => _context.SaveChangesAsync();
}