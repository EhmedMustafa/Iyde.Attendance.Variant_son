namespace Iyde.Attendance.Variant3.DTOs
{
    public class AttendanceEarlyAttemptDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string StoreName { get; set; }
        public DateTime AttemptTime { get; set; }
        public string Reason { get; set; }
        public string Source { get; set; }
    }
}
