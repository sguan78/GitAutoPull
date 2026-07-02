namespace GitHubManager.Core.Services;

public interface ISettingsService
{
    string RootFolderPath { get; set; }
    void Load();
    void Save();
}
