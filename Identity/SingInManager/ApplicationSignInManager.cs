using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FitnessWorkoutTrackerApi.Identity.SingInManager;

public class ApplicationSignInManager(SignInManager<UserApplication> signInManager) : IApplicationSignInManager
{
    public async Task<SignInResult> LoginUserAsync(UserApplication user,  string password)
    {
        return await signInManager.CheckPasswordSignInAsync(
            user: user,
            password: password,
            lockoutOnFailure: false
            );
    }

  
}