using FitnessWorkoutTrackerApi.Exceptions.Comment;
using FitnessWorkoutTrackerApi.Exceptions.Exercise;
using FitnessWorkoutTrackerApi.Exceptions.User;
using FitnessWorkoutTrackerApi.Exceptions.Workout;
using FitnessWorkoutTrackerApi.Response;
using Microsoft.AspNetCore.Diagnostics;

namespace FitnessWorkoutTrackerApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        var (status, message) = exception switch
        {
            UserWrongEmailOrPassword userWrongEmailOrPassword => (StatusCodes.Status402PaymentRequired, userWrongEmailOrPassword.Message),
            UserAlreadyExist userAlreadyExist => (StatusCodes.Status409Conflict, userAlreadyExist.Message),
            UserDoesNotExist userDoesNotExist => (StatusCodes.Status402PaymentRequired, userDoesNotExist.Message),
            WorkoutNotFound workoutNotFound => (StatusCodes.Status404NotFound, workoutNotFound.Message),
            ExerciseNotFound exerciseNotFound => (StatusCodes.Status404NotFound, exerciseNotFound.Message),
            CommentNotFound commentNotFound => (StatusCodes.Status404NotFound, commentNotFound.Message),
            RegisterErrors registerErrors => (StatusCodes.Status400BadRequest, registerErrors.Message),
               
            _ => (500, "Error")
        };

        httpContext.Response.StatusCode = status;

        await httpContext.Response.WriteAsJsonAsync(new ErrorResponse(status, message), cancellationToken);

        
        
        return true;
    }
}