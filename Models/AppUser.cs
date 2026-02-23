using Iyde.Attendance.Variant3.Models.Base;

namespace Iyde.Attendance.Variant3.Models
{
    public class AppUser
    {

        public int Id { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string PassWordHash { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Kim dəyişib? (Sualınızın cavabı budur)
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int? CompanyId { get; set; }


    }
}
