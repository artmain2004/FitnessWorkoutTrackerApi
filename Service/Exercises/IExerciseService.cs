using FitnessWorkoutTrackerApi.Request.Exercises;

namespace FitnessWorkoutTrackerApi.Service.Exercises;

public interface IExerciseService
{
    Task<string> CreateExercise(CreateExerciseRequest createExerciseRequest);
    
    Task<string> UpdateExercise(Guid id, UpdateExerciseRequest createExerciseRequest);
    
    Task<string> DeleteExercise( Guid id);
}