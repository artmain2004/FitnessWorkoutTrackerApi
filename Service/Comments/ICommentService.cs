using FitnessWorkoutTrackerApi.Request.Comments;

namespace FitnessWorkoutTrackerApi.Service.Comments;

public interface ICommentService
{
    Task<string> CreateCommentAsync(CreateCommentRequest createCommentRequest);
    Task<string> DeleteCommentAsync(Guid id);
}