using Serilog;

namespace GitHubManager.Core.Services;

public class LoggerService : ILoggerService
{
    public ILogger Logger { get; }

    public LoggerService()
    {
        Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}
