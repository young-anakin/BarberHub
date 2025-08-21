using BarberHub.DTOs.UserRoleDTO;
using BarberHub.Models;

namespace BarberHub.Services.UserRoleService
{
    public interface IUserRoleService
    {
        Task<UserRole> CreateUserRole(CreateUserRoleDTO DTO);
        Task<UserRole> DeleteUserRole(int userRoleId);
        Task<DisplayUserRoleDTO> GetSpecificUserRole(int userRoleId);
        Task<List<UserRole>> GetUserRoles();
        Task<UserRole> UpdateUserRole(UpdateUserRoleDTO DTO);
    }
}