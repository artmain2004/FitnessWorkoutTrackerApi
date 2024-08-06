using FitnessWorkoutTrackerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTrackerApi.Extensions;

public static class MigrationService
{
   public static WebApplication ApplyMigrations(this WebApplication app)
   {
      using var scope = app.Services.CreateScope();

      using var context = scope.ServiceProvider.GetRequiredService<FitnessWorkoutTrackerDbContext>();
      
      context.Database.Migrate();

      return app;

   }
}