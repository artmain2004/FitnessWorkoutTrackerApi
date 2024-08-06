namespace FitnessWorkoutTrackerApi.Response;

public class ChangePasswordResponse
{
    public int StatusCode { get; set; }
    
    public string Message { get; set; }
    
    public ChangePasswordResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}