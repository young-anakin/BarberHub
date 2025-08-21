using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class CompanyType
    {

        [Key]
        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Company> Companies { get; set; }
    }
}
