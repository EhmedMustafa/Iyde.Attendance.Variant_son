using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceEarlyAttemptController : ControllerBase
    {
        private readonly IAttendanceEarlyAttemptService _attendanceEarlyAttemptService;
        public AttendanceEarlyAttemptController(IAttendanceEarlyAttemptService attendanceEarlyAttemptService)
        {
            _attendanceEarlyAttemptService = attendanceEarlyAttemptService;
        }       

        [HttpGet ("early-attempts")]
        public async Task<IActionResult> GetEarlyAttemptsByEmployee(DateTime? date =null)
        {
            var list= await _attendanceEarlyAttemptService.GetEarlyAttemptsAsync(date);
            return Ok(list);

        }
    }
}
