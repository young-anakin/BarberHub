using BarberHub.DTOs.UserProfileDTO;
using BarberHub.Models;

namespace BarberHub.Services.UserProfileService
{
    public interface IUserProfileService
    {
        Task<UserProfile> CreateUserProfile(CreateUserProfileDTO DTO);
        Task<DisplayUserProfileDTO> GetUserProfile(int userProfileId);
        Task<List<UserProfile>> GetUserProfiles();
        Task<UserProfile> UpdateUserProfile(UpdateUserProfileDTO DTO);
    }
}