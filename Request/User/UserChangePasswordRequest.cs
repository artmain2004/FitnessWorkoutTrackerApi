namespace FitnessWorkoutTrackerApi.Request.User;

public class UserChangePasswordRequest
{
    public string Email { get; set; }

    public string CurrentPassword { get; set; }
    
    public string NewPassword { get; set; }
}