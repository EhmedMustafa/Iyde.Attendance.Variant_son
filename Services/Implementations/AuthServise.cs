using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations
{
    public class AuthServise : IAuthServise
    {
        private readonly IAuthRepository _authRepository;

        public AuthServise(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<AuthResult> LoginAsync(LoginDto loginDto)
        {
            var result= new AuthResult();


            var user = await _authRepository.GetUserByUserName(loginDto.UserName);

            //var companyStores = new List<GetAllStoreDto>();


            if (user == null) 
            {
                result.Success = false;
                result.Message = "İstifadəçi tapılmadı";
                return result;
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.PassWordHash, user.PassWordHash)) 
            {
                result.Success= false;
                result.Message = "Şifrə yanlışdır";
                return result;
            }

            if (!user.IsActive) 
            {
                result.Success= false;
                result.Message = "Sizin hesabınız bloklanıb! Adminlə əlaqə saxlayın.";
                return result;
            }

            result.Success= true;
            result.Message = "Xoş gəldiniz!";
            result.User = user;

            return result;

            //if (user == null) return null;

            //if (!BCrypt.Net.BCrypt.Verify(loginDto.PassWordHash,user.PassWordHash)) return null;

            //if (!user.IsActive) return null;

            //return user;
        }

        public async Task<bool> RegisterAsync(RegisterDto Dto)
        {
            var existingUser= await _authRepository.GetUserByUserName(Dto.UserName);

            if (existingUser != null) return false;

            string passwordhash = BCrypt.Net.BCrypt.HashPassword(Dto.PassWordHash);

            var newUser = new AppUser
            {
                FullName = Dto.UserName,
                UserName = Dto.UserName,
                PassWordHash = passwordhash,
                Role = "Admin",
                IsActive = true,
                CompanyId = Dto.CompanyId
            };

            await _authRepository.RegisterAsync(newUser);
            return true;
        }


    }
}
