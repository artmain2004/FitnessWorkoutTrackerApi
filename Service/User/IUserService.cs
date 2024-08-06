using FitnessWorkoutTrackerApi.Request;
using FitnessWorkoutTrackerApi.Request.User;
using FitnessWorkoutTrackerApi.Response;

namespace FitnessWorkoutTrackerApi.Service.User;

public interface IUserService
{
    Task<RegisterResponse> UserRegisterAsync(UserRegisterRequest registerRequest);
    
    Task<LoginResponse> UserLoginAsync(UserLoginRequest loginRequest);

    Task<string> UserSignOut();
    
    Task<ChangePasswordResponse> UserChangePasswordAsync(UserChangePasswordRequest changePasswordRequest);
}