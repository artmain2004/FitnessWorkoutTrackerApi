using FitnessWorkoutTrackerApi.Data;
using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Repository.Comments;

public class CommentRepository(FitnessWorkoutTrackerDbContext context) : ICommentRepository
{
    public async Task CreateCommentAsync(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid id)
    { 
        await context.Comments
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<bool> IsCommentExistByIdAsync(Guid id)
    {
        return await context.Comments
            .AsNoTracking()
            .AnyAsync(c => c.Id == id);
    }
}