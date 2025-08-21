using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string PaymentType { get; set; } // e.g. Cash, Card, MobileMoney, etc.

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<PaymentDetail> PaymentDetails { get; set; }
    }

}
