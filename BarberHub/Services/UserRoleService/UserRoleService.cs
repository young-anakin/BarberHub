using BarberHub.Context;
using BarberHub.DTOs.UserRoleDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly DataContext _context;
        public UserRoleService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserRole> CreateUserRole(CreateUserRoleDTO DTO)
        {
            var userRole = new UserRole();

            userRole.RoleName = DTO.UserRoleName;

            await _context.Roles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return userRole;
        }

        public async Task<UserRole> UpdateUserRole(UpdateUserRoleDTO DTO)
        {
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == DTO.UserRoleId).FirstOrDefaultAsync();
            if (userRole == null)
            {
                throw new Exception("User Role Not Found");
            }
            userRole.RoleName = DTO.UserRoleName;
            _context.Roles.Update(userRole);
            await _context.SaveChangesAsync();
            return userRole;

        }

        public async Task<UserRole> DeleteUserRole(int userRoleId)
        {
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == userRoleId).FirstOrDefaultAsync();
            if (userRole == null)
            {
                throw new Exception("User Role Not Found");
            }
            _context.Roles.Remove(userRole);
            await _context.SaveChangesAsync();
            return userRole;

        }

        public async Task<List<UserRole>> GetUserRoles()
        {
            var userRole = await _context.Roles.ToListAsync();
            return userRole;
        }

        public async Task<DisplayUserRoleDTO> GetSpecificUserRole(int userRoleId)
        {
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == userRoleId).Include(ur => ur.Users).FirstOrDefaultAsync();
            if (userRole == null)
            {
                throw new Exception("User Role Not Found");
            }
            DisplayUserRoleDTO dto = new DisplayUserRoleDTO();
            dto.Users = userRole.Users;
            dto.UserRoleName = userRole.RoleName;
            dto.UserRoleId = userRoleId;

            return dto;

        }
    }
}
