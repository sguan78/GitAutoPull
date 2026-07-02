using GitHubManager.Core.Models;

namespace GitHubManager.Core.Services;

public class RepositoryService : IRepositoryService
{
    private readonly ILoggerService _logger;

    public RepositoryService(ILoggerService logger)
    {
        _logger = logger;
    }

    public IEnumerable<GitRepositoryInfo> GetRepositories(string rootPath)
    {
        return new List<GitRepositoryInfo>();
    }
}
