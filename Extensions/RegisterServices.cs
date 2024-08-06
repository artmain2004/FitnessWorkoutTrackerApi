using FitnessWorkoutTrackerApi.Identity.SingInManager;
using FitnessWorkoutTrackerApi.Identity.UserManager;
using FitnessWorkoutTrackerApi.Repository.Comments;
using FitnessWorkoutTrackerApi.Repository.Exercises;
using FitnessWorkoutTrackerApi.Repository.Workouts;
using FitnessWorkoutTrackerApi.Service.BearerToken;
using FitnessWorkoutTrackerApi.Service.Comments;
using FitnessWorkoutTrackerApi.Service.Exercises;
using FitnessWorkoutTrackerApi.Service.User;
using FitnessWorkoutTrackerApi.Service.Workouts;

namespace FitnessWorkoutTrackerApi.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddScopedServices(this IServiceCollection service)
    {
        service.AddScoped<IApplicationUserManager, ApplicationUserManager>();
        service.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IBearerTokenService, BearerTokenService>();
        service.AddScoped<IWorkoutRepository, WorkoutRepository>();
        service.AddScoped<ICommentRepository, CommentRepository>();
        service.AddScoped<IExerciseRepository, ExerciseRepository>();
        service.AddScoped<IExerciseService, ExerciseService>();
        service.AddScoped<ICommentService, CommentService>();
        service.AddScoped<IWorkoutService, WorkoutService>();
        
        return service;
    }
}