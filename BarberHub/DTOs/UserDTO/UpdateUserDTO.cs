using BarberHub.Models;

namespace BarberHub.DTOs.UserDTO
{
    public class UpdateUserDTO
    {
        public int UserId {  get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public int? CompanyId { get; set; }
    }
}
