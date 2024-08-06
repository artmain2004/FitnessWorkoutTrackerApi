using FitnessWorkoutTrackerApi.Request.Workouts;
using FitnessWorkoutTrackerApi.Response.Workout;

namespace FitnessWorkoutTrackerApi.Service.Workouts;

public interface IWorkoutService
{
    Task<string> CreateWorkout(CreateWorkoutRequest createWorkoutRequest);

    Task<string> UpdateWorkout( Guid id, UpdateWorkoutRequest updateWorkoutRequest);

    Task<string> DeleteWorkout(Guid id);

    Task<List<AllWorkoutsResponse>> GetAllWorkouts();
    
    Task<SingleWorkoutResponse> GetWorkoutById(Guid id);
    
    Task<List<AllWorkoutsResponse>> GetAllWorkoutsByType(string type);
}