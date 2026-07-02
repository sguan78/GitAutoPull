using Serilog;

namespace GitHubManager.Core.Services;

public interface ILoggerService
{
    ILogger Logger { get; }
}
