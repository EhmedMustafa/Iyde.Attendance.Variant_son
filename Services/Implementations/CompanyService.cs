using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task AddCompanyAsync(CreateCompanyDto company)
        {
            var Company = new Company
            {
                Name = company.Name,
            };
            await _companyRepository.AddCompany(Company);
            return;
        }

        public Task DeleteCompanyAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultCompanyDto>> GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCompanyDto> GetCompanyByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(UpdateCompanydto company)
        {
            throw new NotImplementedException();
        }
    }
}
