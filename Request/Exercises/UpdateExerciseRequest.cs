namespace FitnessWorkoutTrackerApi.Request.Exercises;

public class UpdateExerciseRequest
{
    public string Title { get; set; }
    
    public int Sets { get; set; }
    
    public int Reps { get; set; }
}