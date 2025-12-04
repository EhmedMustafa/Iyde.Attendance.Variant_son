namespace Iyde.Attendance.Variant3.DTOs;

public class ResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public static ResultDto Ok(string msg) => new() { Success = true, Message = msg };
    public static ResultDto Fail(string msg) => new() { Success = false, Message = msg };
}