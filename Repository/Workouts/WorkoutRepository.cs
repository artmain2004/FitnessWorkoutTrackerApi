using FitnessWorkoutTrackerApi.Data;
using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Repository.Workouts;

public class WorkoutRepository(FitnessWorkoutTrackerDbContext context) : IWorkoutRepository
{

    private readonly FitnessWorkoutTrackerDbContext _context = context;


    public async Task<List<Workout>> GetAllWorkoutsAsync()
    {
        return await _context.Workouts
            .AsNoTracking()
            .Include(e => e.Exercises)
            .ToListAsync();
    }

    public async Task<Workout?> GetWorkoutByIdAsync(Guid id)
    {
        return await _context.Workouts
            .AsNoTracking()
            .Include(c => c.Comments)
            .Include(e => e.Exercises)
            .AsSplitQuery()
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task CreateWorkoutAsync(Workout workout)
    {
        await _context.Workouts.AddAsync(workout);

        await _context.SaveChangesAsync();
    }

    public async  Task UpdateWorkoutAsync(Guid id, string title, string type)
    {
        await _context.Workouts
            .Where(w => w.Id == id)
            .ExecuteUpdateAsync(s =>
                s
                    .SetProperty(p => p.Title, title)
                    .SetProperty(p => p.Type, type)
            );


    }

    public async Task DeleteWorkoutAsync(Guid id)
    {
       await  _context.Workouts
            .Where(w => w.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<Workout>> GetAllWorkoutsByTypeAsync(string type)
    {
        return await _context.Workouts
            .AsNoTracking()
            .Include(e => e.Exercises)
            .Where(w => w.Type.ToLower() == type.ToLower())
            .ToListAsync();
    }

    public async Task<bool> IsWorkoutExistByIdAsync(Guid id)
    {
        return await _context.Workouts
            .AsNoTracking()
            .AnyAsync(w => w.Id == id);
    }
}