using Iyde.Attendance.Variant3.DTOs;

namespace Iyde.Attendance.Variant3.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<GetByIdCompanyDto> GetCompanyByIdAsync(int Id);

        //Task<Company> GetCompanyByNameAsync(string name);

        Task<IEnumerable<ResultCompanyDto>> GetAllCompaniesAsync();

        Task AddCompanyAsync(CreateCompanyDto company);

        Task UpdateCompanyAsync(UpdateCompanydto company);

        Task DeleteCompanyAsync(int Id);
    }
}
