namespace BarberHub.DTOs.PaymentDTO
{
    public class DisplayPaymentDTO
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<DisplayPaymentDetailDTO> PaymentDetails { get; set; }
    }

    public class DisplayPaymentDetailDTO
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int PortfolioId { get; set; }
        public string BarberName { get; set; }
        public decimal PriceCharged { get; set; }
        public string? Notes { get; set; }
    }
}
