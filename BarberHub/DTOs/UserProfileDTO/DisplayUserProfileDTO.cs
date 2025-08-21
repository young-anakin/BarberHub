using BarberHub.Models;

namespace BarberHub.DTOs.UserProfileDTO
{
    public class DisplayUserProfileDTO
    {
        public int UserProfileId { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public string? Instagram { get; set; }

        public string? Telegram { get; set; }

        public string? Twitter { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
