using FitnessWorkoutTrackerApi.Models;

namespace FitnessWorkoutTrackerApi.Repository.Exercises;

public interface IExerciseRepository
{
    Task CreateExerciseAsync(Exercise exercise);
    
    Task UpdateExerciseAsync(Guid id, string title, int reps, int sets);
    
    Task DeleteExerciseAsync(Guid id);

    Task<bool> IsExerciseExistByIdAsync(Guid id);
}