using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Services.Interfaces
{
    public interface IAuthServise
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);

        Task<AuthResult>LoginAsync(LoginDto loginDto);
    }
}
