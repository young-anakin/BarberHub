using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class ProvidedService
    {
        [Key]
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public decimal  ServicePrice { get; set; }

        public int EstimatedDurationMinutes { get; set; }

        public int CompanyId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public Company Company { get; set; }
    }
}
