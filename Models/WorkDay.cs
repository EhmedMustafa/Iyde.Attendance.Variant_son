namespace Iyde.Attendance.Variant3.Models;

public class WorkDay
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int StoreId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly? PlannedStart { get; set; }
    public TimeOnly? PlannedEnd { get; set; }
    public bool IsDayOff { get; set; }
}