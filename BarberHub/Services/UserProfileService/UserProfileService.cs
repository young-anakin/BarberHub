using BarberHub.Context;
using BarberHub.DTOs.UserProfileDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.UserProfileService
{
    public class UserProfileService : IUserProfileService
    {
        private readonly DataContext _context;

        public UserProfileService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateUserProfile(CreateUserProfileDTO DTO)
        {
            UserProfile userProfile = new UserProfile();
            var user = await _context.Users.
                            Where(u => u.UserId == DTO.UserId).
                            FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not found");
            }
            userProfile.Email = DTO.Email;
            userProfile.FullName = DTO.FullName;
            userProfile.Instagram = DTO.Instagram;
            userProfile.Telegram = DTO.Telegram;
            userProfile.Twitter = DTO.Twitter;
            userProfile.Gender = DTO.Gender;
            userProfile.PhoneNumber = DTO.PhoneNumber;
            userProfile.UserId = DTO.UserId;
            userProfile.User = user;

            await _context.Profiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;

        }

        public async Task<UserProfile> UpdateUserProfile(UpdateUserProfileDTO DTO)
        {
            var userProfile = await _context.Profiles.Where(u => u.UserProfileId == DTO.UserProfileId).FirstOrDefaultAsync();
            if (userProfile == null)
            {
                throw new Exception("user profile not found");
            }
            var user = await _context.Users.
                            Where(u => u.UserId == DTO.UserId).
                            FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not found");
            }
            userProfile.Email = DTO.Email;
            userProfile.FullName = DTO.FullName;
            userProfile.Instagram = DTO.Instagram;
            userProfile.Telegram = DTO.Telegram;
            userProfile.Twitter = DTO.Twitter;
            userProfile.Gender = DTO.Gender;
            userProfile.PhoneNumber = DTO.PhoneNumber;
            userProfile.UserId = DTO.UserId;
            userProfile.User = user;

            _context.Profiles.Update(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;

        }

        public async Task<DisplayUserProfileDTO> GetUserProfile(int userProfileId)
        {
            DisplayUserProfileDTO displayUserProfileDTO = new DisplayUserProfileDTO();
            var userProfile = await _context.Profiles.Where(u => u.UserProfileId == userProfileId).Include(u => u.User).FirstOrDefaultAsync();
            if (userProfile == null)
            {
                throw new Exception("User Profile Doesn't exist)");
            }
            var user = await _context.Users.Where(u => u.UserId == userProfile.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Profile Doesn't exist)");
            }
            displayUserProfileDTO.UserId = userProfileId;
            displayUserProfileDTO.PhoneNumber = userProfile.PhoneNumber;
            displayUserProfileDTO.FullName = userProfile.FullName;
            displayUserProfileDTO.Gender = userProfile.Gender;
            displayUserProfileDTO.Email = userProfile.Email;
            displayUserProfileDTO.Twitter = userProfile.Twitter;
            displayUserProfileDTO.Instagram = userProfile.Instagram;
            displayUserProfileDTO.Telegram = userProfile.Telegram;
            displayUserProfileDTO.User = user;
            
            return displayUserProfileDTO;


        }

        public async Task<List<UserProfile>> GetUserProfiles()
        {
            var profiles = await _context.Profiles.Include(p => p.User).ToListAsync();
            return profiles;
        }
    }
}
