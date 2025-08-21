namespace BarberHub.DTOs.AppointmentDTO
{
    public class ScheduleAppointmentDTO
    {
        public int PortfolioId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int UserId { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }
    }
}
