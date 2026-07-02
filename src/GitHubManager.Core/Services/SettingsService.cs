using System.Text.Json;
using GitHubManager.Core.Models;

namespace GitHubManager.Core.Services;

public class SettingsService : ISettingsService
{
    private const string FileName = "appsettings.json";
    public string RootFolderPath { get; set; } = string.Empty;

    public void Load()
    {
        if (File.Exists(FileName))
        {
            var json = File.ReadAllText(FileName);
            var settings = JsonSerializer.Deserialize<AppSettings>(json);
            if (settings != null)
                RootFolderPath = settings.RootFolderPath;
        }
    }

    public void Save()
    {
        var settings = new AppSettings { RootFolderPath = RootFolderPath };
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }
}
