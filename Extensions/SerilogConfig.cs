using Serilog;

namespace FitnessWorkoutTrackerApi.Extensions;

public static class SerilogConfig
{
    public static IHostBuilder AddSerilog(this IHostBuilder host)
    {
        host.UseSerilog((ctx, config) =>
        {
            config.WriteTo.Console();
        });

        return host;
    }
}