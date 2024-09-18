using Application_jobs.Context;
using Application_jobs.DTOS;
using Microsoft.EntityFrameworkCore;
namespace Application_jobs.Services
{
    public class CompanyService
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDTO>> GetCompanies()
        {
            var listCompanies = new List<CompanyDTO>();
            var companies = await _context.Company.ToListAsync();
            foreach (var item in companies)
            {
                listCompanies.Add(new CompanyDTO
                {
                    Id = item.Id,
                    Code = item.Code,
                    CompanyName = item.CompanyName,
                });
            }
            return listCompanies;
        }

        public async Task<CompanyDTO> UpdateCompanyById(CompanyDTO company) {
            var companyById = await _context.Company.Where(c => c.Id == company.Id).FirstAsync();

            var companyStorage = new CompanyDTO() { 
                Id = companyById.Id,
                Code = companyById.Code,
                CompanyName = companyById.CompanyName,
            };
            _context.Update(companyStorage);
            await _context.SaveChangesAsync();
            return companyStorage;
        }

        public async Task<string> SaveCompany(CompanyDTO company) { 
            _context.Add(company);
            await _context.SaveChangesAsync();
            return "The company was saved succesfully.";
        }



    }
}
