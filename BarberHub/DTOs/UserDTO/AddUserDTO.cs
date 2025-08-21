namespace BarberHub.DTOs.UserDTO
{
    public class AddUserDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public int? CompanyId { get; set; }
    }
}
