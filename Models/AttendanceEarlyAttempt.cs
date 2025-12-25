namespace Iyde.Attendance.Variant3.Models;

public class AttendanceEarlyAttempt
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; }

    public DateTime AttemptTime { get; set; }
    public string Reason { get; set; }= "";

    public string Source { get; set; } = "Bot";

}
