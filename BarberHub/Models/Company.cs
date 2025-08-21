using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BarberHub.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public int CompanyTypeId { get; set; }

        public string? Location { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public CompanyType CompanyType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        [System.Text.Json.Serialization.JsonIgnore]

        public List<ProvidedService>? ProvidedServices { get; set; }

        public List<Review>? Reviews { get; set; }

        public List<User>? Employees { get; set; }

        [JsonIgnore]
        public List<Payment>? Payments { get; set; }


    }
}
