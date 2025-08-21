using BarberHub.DTOs.CompanyServiceDTO;
using BarberHub.Models;

namespace BarberHub.DTOs.CompanyDTO
{
    public class DisplayCompanyDTO
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public CompanyType CompanyType { get; set; }

        public List<DisplayCompanyServiceDTO>? ProvidedService { get; set; }
    }
}
