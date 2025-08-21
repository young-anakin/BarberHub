namespace BarberHub.Models
{
    public class Review
    {
        public int ReviewId { get; set; }  

        public int Rating { get; set; }

        public string Comment { get; set; }

        public int? CompanyId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public Company Company { get; set; }

        public int ReviewerId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public User ReviewerUser {  get; set; }

        public int? ReviewedUserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public User ReviewedUser { get; set; }
    }
}
