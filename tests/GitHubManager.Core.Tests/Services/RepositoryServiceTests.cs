using GitHubManager.Core.Services;

namespace GitHubManager.Core.Tests.Services;

public class RepositoryServiceTests
{
    private readonly ILoggerService _logger = new LoggerService();

    [Fact]
    public void GetRepositories_ReturnsEmptyList_WhenRootPathEmpty()
    {
        // Arrange
        var service = new RepositoryService(_logger);

        // Act
        var result = service.GetRepositories(string.Empty);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetRepositories_ReturnsEmptyList_WhenRootPathDoesNotExist()
    {
        // Arrange
        var service = new RepositoryService(_logger);

        // Act
        var result = service.GetRepositories(@"C:\NonExistentPath\12345");

        // Assert
        Assert.Empty(result);
    }
}
