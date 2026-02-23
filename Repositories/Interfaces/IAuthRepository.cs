using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task RegisterAsync(AppUser appUser);

        Task<AppUser?> GetUserByUserName(string username);
    }
}
