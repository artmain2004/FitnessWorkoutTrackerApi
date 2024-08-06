using FitnessWorkoutTrackerApi.Models;

namespace FitnessWorkoutTrackerApi.Repository.Workouts;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetAllWorkoutsAsync();

    Task<Workout?> GetWorkoutByIdAsync(Guid id);

    Task CreateWorkoutAsync(Workout workout);

    Task UpdateWorkoutAsync(Guid id, string title, string type);

    Task DeleteWorkoutAsync(Guid id);

    Task<List<Workout>> GetAllWorkoutsByTypeAsync(string type);

    Task<bool> IsWorkoutExistByIdAsync(Guid id);
}