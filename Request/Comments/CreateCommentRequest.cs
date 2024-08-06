namespace FitnessWorkoutTrackerApi.Request.Comments;

public class CreateCommentRequest
{
    public string Body { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid WorkoutId { get; set; }
}