namespace FitnessWorkoutTrackerApi.Models;

public class Comment
{
    public Guid Id { get; set; }

    public string Body { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public Guid WorkoutId { get; set; }


    public Comment(string body, string username, string email, Guid workoutId)
    {
        Id = Guid.NewGuid();
        Body = body;
        Username = username;
        Email = email;
        WorkoutId = workoutId;
    }
    
}