namespace FitnessWorkoutTrackerApi.Response;

public class LoginResponse
{
    public int StatusCode { get; set; }
    
    public string Message { get; set; }
    
    public LoginResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}