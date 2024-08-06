namespace FitnessWorkoutTrackerApi.Models;

public class Exercise
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public int Reps { get; set; }

    public int  Sets { get; set; }

    public Guid WorkoutId { get; set; }

    public Workout Workout { get; set; }


    public Exercise(string title, int reps, int sets, Guid workoutId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Reps = reps;
        Sets = sets;
        WorkoutId = workoutId;
    }
}