namespace FitnessWorkoutTrackerApi.DTO;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Body { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public CommentDto(Guid id, string body, string username, string email)
    {
        Id = id;
        Body = body;
        Username = username;
        Email = email;
    }
}