using FitnessWorkoutTrackerApi.Exceptions.Workout;
using FitnessWorkoutTrackerApi.Models;
using FitnessWorkoutTrackerApi.Repository.Comments;
using FitnessWorkoutTrackerApi.Repository.Workouts;
using FitnessWorkoutTrackerApi.Request.Comments;



namespace FitnessWorkoutTrackerApi.Service.Comments;

public class CommentService(ICommentRepository commentRepository, IWorkoutRepository workoutRepository) : ICommentService
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<string> CreateCommentAsync(CreateCommentRequest createCommentRequest)
    {
        if (!await workoutRepository.IsWorkoutExistByIdAsync(createCommentRequest.WorkoutId)) throw new WorkoutNotFound("Workout not found");
        
        var newComment = new Comment(createCommentRequest.Body, createCommentRequest.Username, createCommentRequest.Email, createCommentRequest.WorkoutId);

        await _commentRepository.CreateCommentAsync(newComment);

        return "Comment created successfully";
    }

    public async Task<string> DeleteCommentAsync(Guid id)
    {

        if (!await commentRepository.IsCommentExistByIdAsync(id)) throw new WorkoutNotFound("Comment not found");
        
        await _commentRepository.DeleteCommentAsync(id);
        
        return "Comment deleted successfully";
    }
}