namespace GitHubManager.Core.Models;

public class GitRepositoryInfo
{
    public string Name { get; set; } = string.Empty;
    public string FullPath { get; set; } = string.Empty;
    public string CurrentBranch { get; set; } = string.Empty;
    public DateTime? LastPullUtc { get; set; }
    public string LastPull => LastPullUtc.HasValue ? LastPullUtc.Value.ToLocalTime().ToString("g") : "Never";
}
