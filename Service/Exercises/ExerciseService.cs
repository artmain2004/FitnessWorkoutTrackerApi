using FitnessWorkoutTrackerApi.Exceptions.Exercise;
using FitnessWorkoutTrackerApi.Exceptions.Workout;
using FitnessWorkoutTrackerApi.Models;
using FitnessWorkoutTrackerApi.Repository.Exercises;
using FitnessWorkoutTrackerApi.Repository.Workouts;
using FitnessWorkoutTrackerApi.Request.Exercises;

namespace FitnessWorkoutTrackerApi.Service.Exercises;

public class ExerciseService(IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository) : IExerciseService
{
    public async Task<string> CreateExercise(CreateExerciseRequest createExerciseRequest)
    {
        
        if (!await workoutRepository.IsWorkoutExistByIdAsync(createExerciseRequest.WorkoutId)) throw new WorkoutNotFound("Workout not found");
        var newExercise = new Exercise(createExerciseRequest.Title, createExerciseRequest.Reps, createExerciseRequest.Sets, createExerciseRequest.WorkoutId);

        await exerciseRepository.CreateExerciseAsync(newExercise);
        
        return "Exercise created successfully";
    }

    public async Task<string> UpdateExercise(Guid id, UpdateExerciseRequest updateExerciseRequest)
    {
        if (!await exerciseRepository.IsExerciseExistByIdAsync(id)) throw new ExerciseNotFound("Exercise not found");
        
        await exerciseRepository.UpdateExerciseAsync(id, updateExerciseRequest.Title, updateExerciseRequest.Reps, updateExerciseRequest.Sets);
        
        return "Exercise updated successfully";
    }

    public async Task<string> DeleteExercise(Guid id)
    {

        if (!await exerciseRepository.IsExerciseExistByIdAsync(id)) throw new ExerciseNotFound("Exercise not found");
        
        await exerciseRepository.DeleteExerciseAsync(id);
        
        return "Exercise deleted successfully";
    }
}