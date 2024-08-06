using FitnessWorkoutTrackerApi.DTO;
using FitnessWorkoutTrackerApi.Exceptions.Workout;
using FitnessWorkoutTrackerApi.Models;
using FitnessWorkoutTrackerApi.Repository.Exercises;
using FitnessWorkoutTrackerApi.Repository.Workouts;
using FitnessWorkoutTrackerApi.Request.Workouts;
using FitnessWorkoutTrackerApi.Response.Workout;
using Serilog;

namespace FitnessWorkoutTrackerApi.Service.Workouts;

public class WorkoutService(IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository)
    : IWorkoutService
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task<string> CreateWorkout(CreateWorkoutRequest createWorkoutRequest)
    {
        var newWorkout = new Workout(createWorkoutRequest.Title, createWorkoutRequest.Type);
        await workoutRepository.CreateWorkoutAsync(newWorkout);

        if (createWorkoutRequest.Exercises.Count != 0)
        {
            foreach (var exercise in createWorkoutRequest.Exercises)
            {
                var newExercise = new Exercise(exercise.Title, exercise.Reps, exercise.Sets, newWorkout.Id);
                
                await _exerciseRepository.CreateExerciseAsync(newExercise);
            }
        }
        
        return "Workout created successfully";
    }

    public async Task<string> UpdateWorkout(Guid id, UpdateWorkoutRequest updateWorkoutRequest)
    {
        if (!await workoutRepository.IsWorkoutExistByIdAsync(id)) throw new WorkoutNotFound("Workout not found");
        
        
        await workoutRepository.UpdateWorkoutAsync(id, updateWorkoutRequest.Title, updateWorkoutRequest.Type);

        return "Workout updated successfully";
    }

    public async Task<string> DeleteWorkout(Guid id)
    {
        if (!await workoutRepository.IsWorkoutExistByIdAsync(id)) throw new WorkoutNotFound("Workout not found");
        await workoutRepository.DeleteWorkoutAsync(id);

        return "Workout deleted successfully";
    }

    public async Task<List<AllWorkoutsResponse>> GetAllWorkouts()
    {
        var workoutsList = await workoutRepository.GetAllWorkoutsAsync();

        var response = workoutsList.Select(w => new AllWorkoutsResponse()
        {
            Id = w.Id,
            Type = w.Type.ToLower(),
            Title = w.Title,
            Exercises = w.Exercises.Select(e => new ExerciseDto(e.Id, e.Title, e.Sets, e.Reps)).ToList()
        })
            .ToList();
        
        Log.Information("List of workouts: {@response}", response);

        return response;
    }

    public async Task<SingleWorkoutResponse> GetWorkoutById(Guid id)
    {
        var workoutById = await workoutRepository.GetWorkoutByIdAsync(id);

        if (workoutById is null) throw new WorkoutNotFound("Workout not found");

        var response = new SingleWorkoutResponse()
        {
            Id = workoutById.Id,
            Title = workoutById.Title,
            Type = workoutById.Type.ToLower(),
            Exercises = workoutById.Exercises.Select(e => new ExerciseDto(e.Id, e.Title, e.Sets, e.Reps)).ToList(),
            Comments = workoutById.Comments.Select(c => new CommentDto(c.Id, c.Body, c.Username, c.Email)).ToList(),
            
        };
        
        Log.Information("Workout by id : {@response}", response);

        return response;
        
    }

    public async Task<List<AllWorkoutsResponse>> GetAllWorkoutsByType(string type)
    {
        var workoutByTypeList = await workoutRepository.GetAllWorkoutsByTypeAsync(type);

        var response = workoutByTypeList.Select(w => new AllWorkoutsResponse()
            {
                Id = w.Id,
                Title = w.Title,
                Type = w.Type.ToLower(),
                Exercises = w.Exercises.Select(e => new ExerciseDto(e.Id, e.Title, e.Sets, e.Reps)).ToList()
            })
            .ToList();
        
        Log.Information("List of workouts by type : {@response}", response);

        return response;
    }
}