using FitnessWorkoutTrackerApi.Models;

namespace FitnessWorkoutTrackerApi.Repository.Comments;

public interface ICommentRepository
{
    Task CreateCommentAsync(Comment comment);

    Task DeleteCommentAsync(Guid id);

    Task<bool> IsCommentExistByIdAsync(Guid id);
}