namespace BarberHub.DTOs.CompanyServiceDTO
{
    public class CreateProvidedServiceDTO
    {

        public string ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public decimal ServicePrice { get; set; }

        public int EstimatedDurationMinutes { get; set; }

        public int CompanyId { get; set; }
    }
}
