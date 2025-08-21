using BarberHub.Context;
using BarberHub.DTOs.CompanyServiceDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.CompanyProvidedService
{
    public class CompanyProvidedService : ICompanyProvidedService
    {
        private readonly DataContext _context;
        public CompanyProvidedService(DataContext context)
        {
            _context = context;
        }
        public async Task<ProvidedService> CreateCompanyProvidedService(CreateProvidedServiceDTO DTO)
        {
            var company = await _context.Companies.Where(c => c.CompanyId == DTO.CompanyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            ProvidedService cps = new ProvidedService();
            cps.ServicePrice = DTO.ServicePrice;
            cps.ServiceName = DTO.ServiceName;
            cps.ServiceDescription = DTO.ServiceDescription;
            cps.EstimatedDurationMinutes = DTO.EstimatedDurationMinutes;
            cps.CompanyId = DTO.CompanyId;
            cps.Company = company;

            await _context.ProvidedServices.AddAsync(cps);
            await _context.SaveChangesAsync();
            return cps;

        }

        public async Task<ProvidedService> UpdateCompanyProvidedService(UpdateProvidedService DTO)
        {
            var company = await _context.Companies.Where(c => c.CompanyId == DTO.CompanyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            var cps = await _context.ProvidedServices.Where(c => c.ServiceId == DTO.ServiceId).FirstOrDefaultAsync();
            if (cps == null)
            {
                throw new Exception("Company Service not found");
            }
            cps.ServicePrice = DTO.ServicePrice;
            cps.ServiceName = DTO.ServiceName;
            cps.ServiceDescription = DTO.ServiceDescription;
            cps.EstimatedDurationMinutes = DTO.EstimatedDurationMinutes;
            cps.CompanyId = DTO.CompanyId;
            cps.Company = company;

            _context.ProvidedServices.Update(cps);
            await _context.SaveChangesAsync();
            return cps;

        }
        public async Task<ProvidedService> DeleteCompanyService(int serviceId)
        {

            var cps = await _context.ProvidedServices.Where(c => c.ServiceId == serviceId).FirstOrDefaultAsync();
            if (cps == null)
            {
                throw new Exception("Company Service not found");
            }


            _context.ProvidedServices.Remove(cps);
            await _context.SaveChangesAsync();
            return cps;

        }

        public async Task<DisplayCompanyServiceDTO> DisplayProvidedService(int serviceId)
        {
            var service = await _context.ProvidedServices.Where(s => s.ServiceId == serviceId).FirstOrDefaultAsync();
            if (service == null)
            {
                throw new Exception("service not found");
            }
            DisplayCompanyServiceDTO display = new DisplayCompanyServiceDTO();
            display.EstimatedDurationMinutes = service.EstimatedDurationMinutes;
            display.CompanyId = service.CompanyId;
            display.ServiceName = service.ServiceName;
            display.ServiceDescription = service.ServiceDescription;
            display.ServicePrice = service.ServicePrice;
            display.Company = service.Company;

            return display;


        }
    }
}
