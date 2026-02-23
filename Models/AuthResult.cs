using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Models
{
    public class AuthResult
    {
        public AppUser? User { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

    }
}
