using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTrackerApi.EntityConfiguration;

public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("exercises");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Title).HasColumnName("title").IsRequired();
        builder.Property(p => p.Sets).HasColumnName("sets").IsRequired();
        builder.Property(p => p.Reps).HasColumnName("reps").IsRequired();
        builder.Property(p => p.WorkoutId).HasColumnName("workout_id").IsRequired();
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
    }
}