using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;

namespace Iyde.Attendance.Variant3.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddCompany(Company company)
        {
           return Task.Run(() =>
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
            });
        }

        public Task DeleteCompany(int Id)
        {
            _context.Companies.Remove(_context.Companies.Find(Id));
            return Task.Run(() => _context.SaveChanges());
        }


        public Task<IEnumerable<Company>> GetAllCompanies()
        {
            _context.Companies.ToList();
            return Task.FromResult(_context.Companies.AsEnumerable());
        }

        public Task<Company> GetCompanyById(int Id)
        {
            _context.Companies.Find(Id);
            return Task.FromResult(_context.Companies.Find(Id));
        }

        public Task UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            return Task.Run(() => _context.SaveChanges());
        }
    }
}
