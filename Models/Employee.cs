namespace Iyde.Attendance.Variant3.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PersonalQr { get; set; } = string.Empty;
    public int StoreId { get; set; }
    public Store Store { get; set; }
}