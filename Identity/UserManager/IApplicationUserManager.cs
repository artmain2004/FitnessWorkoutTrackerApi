using Microsoft.AspNetCore.Identity;

namespace FitnessWorkoutTrackerApi.Identity.UserManager;

public interface IApplicationUserManager
{
    Task<IdentityResult> CreateUserAsync(UserApplication user, string password);
    
    Task<bool> CheckUserPasswordAsync(UserApplication user, string password);

    Task<bool> IsUserExistByEmailAsync(string email);

    Task<UserApplication?> GetUserByEmailAsync(string email);

    Task<IdentityResult> ChangeUserPasswordAsync(UserApplication user, string currentPassword, string newPassword);
}