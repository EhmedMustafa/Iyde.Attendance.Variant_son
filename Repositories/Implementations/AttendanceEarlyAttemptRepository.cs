using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Repositories.Implementations;

    public class AttendanceEarlyAttemptRepository : IAttendanceEarlyAttemptRepository
    {

        private readonly ApplicationDbContext _context;
        public AttendanceEarlyAttemptRepository(ApplicationDbContext context) => _context = context;
       
        public async Task AddAsync(AttendanceEarlyAttempt attendanceEarly)
        {
            await _context.AttendanceEarlyAttempts.AddAsync(attendanceEarly);
        }

    public Task<List<AttendanceEarlyAttempt>> GetByDateAsync(DateTime? date)
    {
        return _context.AttendanceEarlyAttempts
            .Include(x => x.Employee)
            .Include(x => x.Store)
            .Where(a => a.AttemptTime.Date == date)
            .OrderByDescending(a => a.AttemptTime)
            .ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}


