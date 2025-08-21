using BarberHub.DTOs.CompanyServiceDTO;
using BarberHub.Models;

namespace BarberHub.Services.CompanyProvidedService
{
    public interface ICompanyProvidedService
    {
        Task<ProvidedService> CreateCompanyProvidedService(CreateProvidedServiceDTO DTO);
        Task<ProvidedService> DeleteCompanyService(int serviceId);
        Task<DisplayCompanyServiceDTO> DisplayProvidedService(int serviceId);
        Task<ProvidedService> UpdateCompanyProvidedService(UpdateProvidedService DTO);
    }
}