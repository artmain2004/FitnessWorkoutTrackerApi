using FitnessWorkoutTrackerApi.Data;
using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Repository.Exercises;

public class ExerciseRepository(FitnessWorkoutTrackerDbContext context) : IExerciseRepository
{
    public async Task CreateExerciseAsync(Exercise exercise)
    {
        await context.Exercises.AddAsync(exercise);

        await context.SaveChangesAsync();
    }

    public async Task UpdateExerciseAsync(Guid id, string title, int sets, int reps)
    {
        await context.Exercises
            .Where(e => e.Id == id)
            .ExecuteUpdateAsync(s =>
                s
                    .SetProperty(p => p.Title, title)
                    .SetProperty(p => p.Reps, reps)
                    .SetProperty(p => p.Sets, sets)
                );
    }

    public async Task DeleteExerciseAsync(Guid id)
    {
        await context.Exercises
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<bool> IsExerciseExistByIdAsync(Guid id)
    {
        return await context.Exercises
            .AsNoTracking()
            .AnyAsync(e => e.Id == id);
    }
}