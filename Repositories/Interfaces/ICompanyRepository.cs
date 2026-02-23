using Iyde.Attendance.Variant3.Models;

namespace Iyde.Attendance.Variant3.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(int Id);

        //Task<Company> GetCompanyByNameAsync(string name);

        Task<IEnumerable<Company>> GetAllCompanies();

        Task AddCompany(Company company);

        Task UpdateCompany(Company company);

        Task DeleteCompany(int Id);

    }
}
