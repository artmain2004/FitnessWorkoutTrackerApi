namespace FitnessWorkoutTrackerApi.DTO;

public class ExerciseDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Sets { get; set; }
    
    public int Reps { get; set; }

    public ExerciseDto(Guid id, string title, int sets, int reps)
    {
        Id = id;
        Title = title;
        Sets = sets;
        Reps = reps;
    }
}