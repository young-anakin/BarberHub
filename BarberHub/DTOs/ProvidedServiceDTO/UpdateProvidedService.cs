namespace BarberHub.DTOs.CompanyServiceDTO
{
    public class UpdateProvidedService
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public decimal ServicePrice { get; set; }

        public int EstimatedDurationMinutes { get; set; }

        public int CompanyId { get; set; }
    }
}
