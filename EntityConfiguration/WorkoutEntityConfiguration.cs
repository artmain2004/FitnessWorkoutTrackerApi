using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTrackerApi.EntityConfiguration;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("workouts");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Title).HasColumnName("title");
        builder.Property(p => p.Type).HasColumnName("type");

        builder
            .HasMany<Exercise>(w => w.Exercises)
            .WithOne(e => e.Workout)
            .HasForeignKey(e => e.WorkoutId);

        builder
            .HasMany<Comment>(c => c.Comments)
            .WithOne()
            .HasForeignKey(c => c.WorkoutId);
    }
}