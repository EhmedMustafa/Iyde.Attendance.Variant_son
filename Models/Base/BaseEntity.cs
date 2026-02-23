namespace Iyde.Attendance.Variant3.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        // Kim yaradıb?
        //public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Kim dəyişib? (Sualınızın cavabı budur)
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
