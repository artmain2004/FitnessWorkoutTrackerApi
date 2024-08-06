using FitnessWorkoutTrackerApi.Request.Exercises;

namespace FitnessWorkoutTrackerApi.Request.Workouts;

public class CreateWorkoutRequest
{
    public string Title { get; set; }

    public string Type { get; set; }

    public List<CreateExerciseRequest> Exercises { get; set; }

   
}