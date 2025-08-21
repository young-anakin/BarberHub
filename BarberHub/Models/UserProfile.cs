using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }   

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public string? Instagram { get; set; }

        public string? Telegram { get; set; }

        public string? Twitter { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User User { get; set; }
    }
}
