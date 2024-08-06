using FitnessWorkoutTrackerApi.DTO;

namespace FitnessWorkoutTrackerApi.Response.Workout;

public class AllWorkoutsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;


    public List<ExerciseDto> Exercises { get; set; }
}