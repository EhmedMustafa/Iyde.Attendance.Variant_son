namespace Iyde.Attendance.Variant3.DTOs;

public class EmployeeDayStatusDto
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;

    public DateOnly Date { get; set; }

    // yeni əlavə edilənlər
    public TimeOnly? PlannedStart { get; set; }
    public TimeOnly? PlannedEnd { get; set; }

    public string PlannedRange { get; set; } = "";
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }

    public string Status { get; set; } = string.Empty;
    public int MinutesLate { get; set; }
    public int MinutesEarlyLeave { get; set; }
    public int WorkedMinutes { get; set; }
}

public class DailyReportDto
{
    public DateOnly Date { get; set; }
    public List<EmployeeDayStatusDto> Items { get; set; } = new();
}