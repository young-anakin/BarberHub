using BarberHub.Context;
using BarberHub.DTOs.UserDTO;
using BarberHub.DTOs.UserRoleDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(AddUserDTO DTO)
        {
            var user = new User();
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == DTO.UserRoleId).FirstOrDefaultAsync();

            if (userRole == null)
            {
                throw new Exception("User Role not found");
            }


            user.UserRoleId = DTO.UserRoleId;
            user.UserName = DTO.UserName;
            user.UserRole = userRole;
            user.Password = DTO.Password;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(UpdateUserDTO DTO)
        {
            var user = await _context.Users.Where(u => u.UserId == DTO.UserId).FirstOrDefaultAsync();
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == DTO.UserRoleId).FirstOrDefaultAsync();


            if (userRole == null || user == null)
            {
                throw new Exception("User or User Role not found");
            }


            user.UserRoleId = DTO.UserRoleId;
            user.UserName = DTO.Username;
            user.UserRole = userRole;
            user.Password = DTO.Password;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not found");
            }



            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<DisplayUserDTO> GetSpecificUser(int id)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            var userProfile = await _context.Profiles.Where(u => u.UserId == id).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var userRole = await _context.Roles.Where(ur => ur.UserRoleId == user.UserRoleId).FirstOrDefaultAsync();
            if (userRole == null)
            {
                throw new Exception("User Role not found");
            }
            DisplayUserDTO displayUserDTO = new DisplayUserDTO();
            displayUserDTO.UserId = user.UserId;
            displayUserDTO.UserName = user.UserName;
            displayUserDTO.UserRoleId = user.UserRoleId;
            displayUserDTO.UserRole = userRole;
            displayUserDTO.UserProfile = userProfile;

            return displayUserDTO;
        }

        public async Task<List<DisplayUserDTO>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            var userIds = users.Select(u => u.UserId).ToList();
            var userRoleIds = users.Select(u => u.UserRoleId).Distinct().ToList();

            var userRoles = await _context.Roles
                .Where(r => userRoleIds.Contains(r.UserRoleId))
                .ToDictionaryAsync(r => r.UserRoleId);

            var userProfiles = await _context.Profiles
                .Where(p => userIds.Contains(p.UserId))
                .ToDictionaryAsync(p => p.UserId);

            var displayUsers = users.Select(user => new DisplayUserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserRoleId = user.UserRoleId,
                UserRole = userRoles.TryGetValue(user.UserRoleId, out var role) ? role : null,
                UserProfile = userProfiles.TryGetValue(user.UserId, out var profile) ? profile : null
            }).ToList();

            return displayUsers;
        }

    }
}
