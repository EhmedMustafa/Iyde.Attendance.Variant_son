using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; }

        public string PassWordHash { get; set; }
    }
}
