using BarberHub.Models;

namespace BarberHub.DTOs.CompanyTypeDTO
{
    public class DisplayCompanyTypeDTO
    {
        public int CompanyTypeId { get; set; }

        public string CompanyTypeName { get; set; }

        public List<Company> Companies { get; set; }
    }
}
