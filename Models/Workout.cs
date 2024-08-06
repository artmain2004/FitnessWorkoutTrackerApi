namespace FitnessWorkoutTrackerApi.Models;

public class Workout
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public List<Comment> Comments { get; set; }

    public List<Exercise> Exercises { get; set; }

    

    public Workout(string title, string type)
    {
        Id = Guid.NewGuid();
        Title = title;
        Type = type;
        
    }
    
    
}