using System.Reflection;
using FitnessWorkoutTrackerApi.Identity;
using FitnessWorkoutTrackerApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Data;

public class FitnessWorkoutTrackerDbContext : IdentityDbContext<UserApplication>
{
    public FitnessWorkoutTrackerDbContext()
    {
        
    }

    public DbSet<Workout> Workouts { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("{your_connection_string_to_database}");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}