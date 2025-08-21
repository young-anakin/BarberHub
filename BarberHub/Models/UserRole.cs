using System.ComponentModel.DataAnnotations;

namespace BarberHub.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        public string RoleName { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public List<User> Users { get; set; }

        // will add Roles here
    }
}
