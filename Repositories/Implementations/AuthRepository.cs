using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetUserByUserName(string username)
        {
            return await _context.appUsers.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task RegisterAsync(AppUser appUser)
        {
            await _context.appUsers.AddAsync(appUser);
            await _context.SaveChangesAsync();
        }
    }
}
