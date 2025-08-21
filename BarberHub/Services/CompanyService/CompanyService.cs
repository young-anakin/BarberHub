using BarberHub.Context;
using BarberHub.DTOs.CompanyDTO;
using BarberHub.DTOs.CompanyServiceDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;

        public CompanyService(DataContext context)
        {
            _context = context;
        }

        public async Task<Company> RegisterCompany(RegisterCompanyDTO DTO)
        {
            Company company = new Company();

            // CompanyType Details
            var companyType = await _context.CompanyTypes.FirstOrDefaultAsync(ct => ct.CompanyTypeId == DTO.CompanyTypeId);

            var owner = await _context.Users.Where(o => o.UserId == DTO.OwnerId).FirstOrDefaultAsync();
            if (owner == null)
            {
                throw new Exception("Owner not found");
            }

            if (companyType == null)
            {
                throw new Exception("Company Type not found");
            }

            // Company Details
            company.CompanyDescription = DTO.CompanyDescription;
            company.CompanyName = DTO.CompanyName;
            company.CompanyType = companyType;
            company.CompanyTypeId = DTO.CompanyTypeId;
            company.UserId = DTO.OwnerId;
            company.User = owner;




            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompany(UpdateComapnyDTO DTO)
        {
            var company = await _context.Companies.Where(c => c.CompanyId == DTO.CompanyId).FirstOrDefaultAsync();
            var companyType = await _context.CompanyTypes.Where(ct => ct.CompanyTypeId == DTO.CompanyTypeId).FirstOrDefaultAsync();
            if (companyType == null)
            {
                throw new Exception("CompanyType not found");
            }
            if (company == null)
            {
                throw new Exception("Company not found");
            }

            company.CompanyDescription = DTO.CompanyDescription;
            company.CompanyName = DTO.CompanyName;
            company.LastUpdatedAt = DateTime.Now;

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;

        }

        public async Task<Company> DeleteCompany(int id)
        {
            var company = await _context.Companies.Where(c => c.CompanyId == id).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new Exception("Company not found");
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<List<DisplayCompanyDTO>> GetAllCompanies()
        {
            var companies = await _context.Companies.Include(c => c.CompanyType).Include(c => c.ProvidedServices).ToListAsync();
            return companies.Select(company => new DisplayCompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyDescription = company.CompanyDescription,
                CompanyType = company.CompanyType,
                ProvidedService = company.ProvidedServices.Select(service => new DisplayCompanyServiceDTO
                {
                    ServiceName = service.ServiceName,
                    ServiceDescription = service.ServiceDescription,
                    ServicePrice = service.ServicePrice,
                    EstimatedDurationMinutes = service.EstimatedDurationMinutes,
                    CompanyId = service.CompanyId,
                    Company = null // You might optionally skip this if not needed
                }).ToList()
            }).ToList();

        }

        public async Task<DisplayCompanyDTO> GetSpecificCompany(int companyId)
        {
            var company = await _context.Companies
                .Include(c => c.ProvidedServices)
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (company == null)
            {
                throw new Exception("Company not found.");
            }

            var companyDTO = new DisplayCompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyDescription = company.CompanyDescription,
                CompanyType = company.CompanyType,
                ProvidedService = company.ProvidedServices.Select(service => new DisplayCompanyServiceDTO
                {
                    ServiceName = service.ServiceName,
                    ServiceDescription = service.ServiceDescription,
                    ServicePrice = service.ServicePrice,
                    EstimatedDurationMinutes = service.EstimatedDurationMinutes,
                    CompanyId = service.CompanyId,
                    Company = null // Optional: avoid circular reference or heavy data
                }).ToList()
            };

            return companyDTO;
        }


    }
}
