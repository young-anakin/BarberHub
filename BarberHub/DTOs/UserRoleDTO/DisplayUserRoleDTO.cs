using BarberHub.Models;

namespace BarberHub.DTOs.UserRoleDTO
{
    public class DisplayUserRoleDTO
    {
        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        public List<User> Users { get; set; }

    }
}
