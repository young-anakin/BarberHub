using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }

        public string SpecialtyName { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public ICollection<Portfolio>? Portfolios { get; set; }
    }

}
