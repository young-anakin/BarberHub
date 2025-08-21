using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public int ServiceId { get; set; }
        public ProvidedService Service { get; set; }

        public int PortfolioId { get; set; }  // who did the job
        public Portfolio Portfolio { get; set; }

        public decimal PriceCharged { get; set; }

        public string? Notes { get; set; }  // Optional: haircut + beard, extra time, etc.
    }

}
