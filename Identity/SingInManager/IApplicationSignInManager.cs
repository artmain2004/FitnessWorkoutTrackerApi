
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FitnessWorkoutTrackerApi.Identity.SingInManager;

public interface IApplicationSignInManager
{
    Task<SignInResult> LoginUserAsync(UserApplication user,  string password);

    
}