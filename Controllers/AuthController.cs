using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServise _authServise;
        private readonly IStoreService _storeService;

        public AuthController(IAuthServise authServise, IStoreService storeService)
        {
            _authServise = authServise;
            _storeService = storeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto) 
        {
            var result= await _authServise.RegisterAsync(dto);

            if (!result)
            {
                return BadRequest("Bu istifadəçi adı artıq mövcuddur.");
            }

            return Ok("Qeydiyyat uğurludur!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto Dto) 
        {
            var user = await _authServise.LoginAsync(Dto);

            //if (user == null) return Unauthorized("İstifadəçi adı və ya şifrə səhvdir.");

            // if (!user.IsActive) return BadRequest("Sizin istifadəçi adınız bloklanıb!");

           var comstores= await _storeService.GetStoresByCompanyIdAsync(user.User.CompanyId);

            if (!user.Success)
            {
                return BadRequest(user.Message);
            }

            return Ok(new LoginResponse
            {
                UserName=user.User.UserName,
                CompanyId = user.User.CompanyId,
                
                Stores = comstores
            }
            );
        


        }

    }
}
