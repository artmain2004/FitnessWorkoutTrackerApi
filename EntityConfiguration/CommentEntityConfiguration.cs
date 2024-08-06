using FitnessWorkoutTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTrackerApi.EntityConfiguration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Body).HasColumnName("body").IsRequired();
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.Username).HasColumnName("username").IsRequired();
        builder.Property(p => p.Email).HasColumnName("email").IsRequired();
        builder.Property(p => p.WorkoutId).HasColumnName("workout_id").IsRequired();
    }
}