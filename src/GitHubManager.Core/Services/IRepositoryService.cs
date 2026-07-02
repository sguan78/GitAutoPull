using GitHubManager.Core.Models;

namespace GitHubManager.Core.Services;

public interface IRepositoryService
{
    IEnumerable<GitRepositoryInfo> GetRepositories(string rootPath);
}
