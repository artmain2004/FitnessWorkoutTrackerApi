using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Identity.UserManager;

public class ApplicationUserManager(UserManager<UserApplication> userManager) : IApplicationUserManager
{
    public async Task<IdentityResult> CreateUserAsync(UserApplication user, string password)
    {
        return await userManager.CreateAsync(user, password);
    }

    public async Task<bool> CheckUserPasswordAsync(UserApplication user, string password)
    {
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> IsUserExistByEmailAsync(string email)
    {
        return await userManager.Users.AnyAsync(u => u.Email == email);
    }

    public async  Task<UserApplication?> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
        
    }

    public async  Task<IdentityResult> ChangeUserPasswordAsync(UserApplication user, string currentPassword, string newPassword)
    {
        return await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}