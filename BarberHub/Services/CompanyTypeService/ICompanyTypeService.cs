using BarberHub.DTOs.CompanyTypeDTO;
using BarberHub.Models;

namespace BarberHub.Services.CompanyTypeService
{
    public interface ICompanyTypeService
    {
        Task<CompanyType> DeleteCompanyType(int CompanyTypeId);
        Task<List<CompanyType>> GetAllCompanyTypes();
        Task<DisplayCompanyTypeDTO> GetCompanyType(int CompanyTypeId);
        Task<CompanyType> RegisterCompanyType(RegisterCompanyTypeDTO DTO);
        Task<CompanyType> UpdateCompanyType(UpdateCompanyTypeDTO DTO);
    }
}