using System.ComponentModel.DataAnnotations;

namespace BarberHub.DTOs.PaymentDTO
{
    public class AddPaymentDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string PaymentType { get; set; } // Cash, Card, etc.

        [Required]
        public List<AddPaymentDetailDTO> PaymentDetails { get; set; }
    }

    public class AddPaymentDetailDTO
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int PortfolioId { get; set; }  // The professional who performed the service

        [Required]
        public decimal PriceCharged { get; set; }

        public string? Notes { get; set; } // Optional: custom remarks
    }
}
