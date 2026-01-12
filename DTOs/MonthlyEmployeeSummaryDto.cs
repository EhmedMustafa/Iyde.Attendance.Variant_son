namespace Iyde.Attendance.Variant3.DTOs
{
    public class MonthlyEmployeeSummaryDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public int StoreId { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public int AbsentDays { get; set; }

        public int TotalLateMinitus { get; set; }

        public int TotalEarlyLeaveMinutes { get; set; }


    }
}
