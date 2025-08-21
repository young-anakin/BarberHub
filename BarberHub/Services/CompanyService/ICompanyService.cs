using BarberHub.DTOs.CompanyDTO;
using BarberHub.Models;

namespace BarberHub.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<Company> DeleteCompany(int id);
        Task<List<DisplayCompanyDTO>> GetAllCompanies();
        Task<DisplayCompanyDTO> GetSpecificCompany(int CompanyId);
        Task<Company> RegisterCompany(RegisterCompanyDTO DTO);
        Task<Company> UpdateCompany(UpdateComapnyDTO DTO);
    }
}