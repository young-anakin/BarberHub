using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }


    }
}
