using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
        {
            await _companyService.AddCompanyAsync(dto);
            return Ok();
        }
    }
}
