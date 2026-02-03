using Serilog;
using Serilog.Events;

namespace Procat.WebAPI.Configuration;

public static class LoggingConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public void ConfigureLogging()
        {
            builder.Services.AddSerilog(
                (services, loggerConfig) =>
                    loggerConfig
                        .ReadFrom.Configuration(builder.Configuration)
                        .ReadFrom.Services(services)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
            );
        }
    }

    public static void CreateBootstrapLogger()
    {
        var envName =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? "Production";

        var level = envName.Equals("Development", StringComparison.OrdinalIgnoreCase)
            ? LogEventLevel.Debug
            : LogEventLevel.Information;

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(level)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        Log.Information("Log level: {logLevel}", level);
    }
}
