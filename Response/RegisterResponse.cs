namespace FitnessWorkoutTrackerApi.Response;

public class RegisterResponse
{
    public int StatusCode { get; set; }

    public string Message { get; set; }

 
    
    


    public RegisterResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}