using FitnessWorkoutTrackerApi.DTO;

namespace FitnessWorkoutTrackerApi.Response.Workout;

public class SingleWorkoutResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public List<CommentDto> Comments { get; set; }

    public List<ExerciseDto> Exercises { get; set; }
}