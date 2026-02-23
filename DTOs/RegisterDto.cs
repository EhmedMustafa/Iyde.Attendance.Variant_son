namespace Iyde.Attendance.Variant3.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string PassWordHash { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        public int? CompanyId { get; set; }
    }
}
