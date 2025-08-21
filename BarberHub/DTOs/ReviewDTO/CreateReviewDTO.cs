namespace BarberHub.DTOs.ReviewDTO
{
    public class CreateReviewDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int ReviewerId { get; set; }
        public int? CompanyId { get; set; }
        public int? ReviewedId { get; set; }
    }
}
