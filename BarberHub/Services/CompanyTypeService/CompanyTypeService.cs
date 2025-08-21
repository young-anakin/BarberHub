using BarberHub.Context;
using BarberHub.DTOs.CompanyTypeDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.CompanyTypeService
{
    public class CompanyTypeService : ICompanyTypeService
    {

        private readonly DataContext _context;

        public CompanyTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<CompanyType> RegisterCompanyType(RegisterCompanyTypeDTO DTO)
        {
            CompanyType companyType = new CompanyType();
            companyType.CompanyTypeName = DTO.CompanyType;

            await _context.CompanyTypes.AddAsync(companyType);
            await _context.SaveChangesAsync();
            return companyType;
        }

        public async Task<CompanyType> UpdateCompanyType(UpdateCompanyTypeDTO DTO)
        {

            var companyType = await _context.CompanyTypes.
                Where(c => c.CompanyTypeId == DTO.CompanyTypeId)
                .FirstOrDefaultAsync();

            if (companyType == null)
            {
                throw new Exception("Company type not found.");

            }
            companyType.CompanyTypeName = DTO.CompanyName;

            _context.CompanyTypes.Update(companyType);
            await _context.SaveChangesAsync();
            return companyType;
        }

        public async Task<List<CompanyType>> GetAllCompanyTypes()
        {
            var companyTypes = await _context.CompanyTypes.ToListAsync();
            return companyTypes;
        }

        public async Task<CompanyType> DeleteCompanyType(int CompanyTypeId)
        {
            var companyType = await _context.CompanyTypes.Where(c => c.CompanyTypeId == CompanyTypeId).FirstOrDefaultAsync();
            if (companyType == null)
            {
                throw new Exception("Company Type Not Found");
            }
            else
            {
                _context.CompanyTypes.Remove(companyType);
                await _context.SaveChangesAsync();
                return companyType;
            }

        }

        public async Task<DisplayCompanyTypeDTO> GetCompanyType(int CompanyTypeId)
        {
            var ct = await _context.CompanyTypes.Where(ct => ct.CompanyTypeId == CompanyTypeId).Include(ct => ct.Companies).FirstOrDefaultAsync();  
            if (ct == null)
            {
                throw new Exception("Company Type not found");
            }
            
            DisplayCompanyTypeDTO companyTypeDTO = new DisplayCompanyTypeDTO();

            companyTypeDTO.CompanyTypeId = ct.CompanyTypeId;
            companyTypeDTO.CompanyTypeName = ct.CompanyTypeName;

            companyTypeDTO.Companies = ct.Companies;

            return companyTypeDTO;


        }
    }
}
