using System.Text.Json;
using FitnessWorkoutTrackerApi.Exceptions.User;
using FitnessWorkoutTrackerApi.Identity;
using FitnessWorkoutTrackerApi.Identity.SingInManager;
using FitnessWorkoutTrackerApi.Identity.UserManager;
using FitnessWorkoutTrackerApi.Request.User;
using FitnessWorkoutTrackerApi.Response;
using FitnessWorkoutTrackerApi.Service.BearerToken;
using Serilog;

namespace FitnessWorkoutTrackerApi.Service.User;

public class UserService(
    IApplicationUserManager userManager,
    IApplicationSignInManager signInManager,
    IBearerTokenService tokenService,
    IHttpContextAccessor httpContextAccessor
    
    
   )
    : IUserService
{
    public async Task<RegisterResponse> UserRegisterAsync(UserRegisterRequest registerRequest)
    {
        var userByEmail = await userManager.IsUserExistByEmailAsync(registerRequest.Email);

        if (userByEmail) throw new UserAlreadyExist("A user with this email already exists");

        var newUser = new UserApplication()
        {
            UserName = registerRequest.Username,
            Email = registerRequest.Email
        };

        var registerResult = await userManager.CreateUserAsync(newUser, registerRequest.Password);

        if (!registerResult.Succeeded)
        {
            var registerError = registerResult.Errors
                .Select(e => new { e.Description });

            var errorString = JsonSerializer.Serialize(registerError);

            Log.Information("Errors: {@errorString}", errorString);

            throw new RegisterErrors(errorString);
        }

        

        
        return new RegisterResponse(StatusCodes.Status200OK, "User successfully registered");

    }

    public async Task<LoginResponse> UserLoginAsync(UserLoginRequest loginRequest)
    {
        var userByEmail = await userManager.GetUserByEmailAsync(loginRequest.Email);

        if (userByEmail is null) throw new UserDoesNotExist("A user with such an email does not exist");
       

        var loginResult = await signInManager.LoginUserAsync(userByEmail, loginRequest.Password);

        if (!loginResult.Succeeded)
        {
            throw new UserWrongEmailOrPassword("Wrong email or password");
        }
        
        tokenService.GenerateBearerToken(userByEmail.UserName, userByEmail.Email);
        
        return new LoginResponse(StatusCodes.Status200OK, "Login Successful");

    }

    public async Task<string> UserSignOut()
    {
        httpContextAccessor.HttpContext?.Response.Cookies.Delete("bearer-token");

        return "User signed out";
    }

 

    public async Task<ChangePasswordResponse> UserChangePasswordAsync(UserChangePasswordRequest changePasswordRequest)
    {
        var userByEmail = await userManager.GetUserByEmailAsync(changePasswordRequest.Email);

        if (userByEmail is null)  throw new UserDoesNotExist("A user with such an email does not exist");
        

        var changePasswordResult = await userManager.ChangeUserPasswordAsync(
            userByEmail,
            changePasswordRequest.CurrentPassword,
            changePasswordRequest.NewPassword
            );

        if (!changePasswordResult.Succeeded)
        {
            var errorChangePassword = changePasswordResult.Errors
                .Select(e => new { e.Description });
            Log.Information("Errors: @{errorChangePassword}", errorChangePassword);
        }

        return new ChangePasswordResponse(StatusCodes.Status200OK, "Password Changed");

    }
}