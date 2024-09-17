using Application_jobs.Context;
using Application_jobs.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application_jobs.Services
{
    public class ApplicationStatusService
    {
        private readonly AppDbContext _context;
        public ApplicationStatusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationStatusDTO>> GetApplicationStatus() {
            var listStatus = new List<ApplicationStatusDTO>();
            var status = await _context.ApplicationStatus.ToListAsync();
            foreach (var item in status)
            {
                listStatus.Add(new ApplicationStatusDTO
                {
                    Id = item.Id,
                    Code = item.Code,
                    Description = item.Description,
                });
            }
            return listStatus;
        }
    }
}
