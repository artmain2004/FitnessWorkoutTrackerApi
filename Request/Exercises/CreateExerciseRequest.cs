namespace FitnessWorkoutTrackerApi.Request.Exercises;

public class CreateExerciseRequest
{
    public string Title { get; set; }

    public int Sets { get; set; }
    
    public int Reps { get; set; }

    public Guid WorkoutId { get; set; }
}