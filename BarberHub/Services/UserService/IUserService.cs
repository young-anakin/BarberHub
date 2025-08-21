using BarberHub.DTOs.UserDTO;
using BarberHub.Models;

namespace BarberHub.Services.UserService
{
    public interface IUserService
    {
        Task<User> CreateUser(AddUserDTO DTO);
        Task<User> DeleteUser(int id);
        Task<List<DisplayUserDTO>> GetAllUsers();
        Task<DisplayUserDTO> GetSpecificUser(int id);
        Task<User> UpdateUser(UpdateUserDTO DTO);
    }
}