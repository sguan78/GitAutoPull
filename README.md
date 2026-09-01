# GitAutoPull

A WPF desktop application for bulk pulling Git repositories. Point it at a root folder, and it recursively discovers all Git repositories, letting you pull them individually or all at once.

## Features

- **Recursive discovery** — Scans a root folder and all subdirectories for `.git` repositories
- **Bulk operations** — Pull selected repository or pull all discovered repositories in one click
- **Branch awareness** — Shows current branch for each repository
- **Last pull tracking** — Remembers when each repository was last pulled
- **Persistent settings** — Root folder path saved between sessions
- **Clean MVVM architecture** — Separation of concerns with CommunityToolkit.Mvvm

## Screenshots

*(Add screenshots here after building)*

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (or later)
- Windows 10/11 (WPF application)
- Git installed and in PATH

## Quick Start

```bash
# Clone the repository
git clone https://github.com/yourusername/GitAutoPull.git
cd GitAutoPull

# Restore dependencies
dotnet restore

# Build
dotnet build

# Run
dotnet run --project src/GitHubManager.Wpf
```

## Usage

1. **Launch** the application
2. **Click "Browse..."** and select a root folder containing your Git repositories
3. **Click "Refresh"** to scan for repositories
4. **Select a repository** and click "Pull Selected" — or click "Pull All" to update everything

## Architecture

```
GitAutoPull/
├── src/
│   ├── GitHubManager.Core/          # Core library (net10.0)
│   │   ├── Models/                  # GitRepositoryInfo, AppSettings
│   │   └── Services/                # RepositoryService, SettingsService, LoggerService
│   └── GitHubManager.Wpf/           # WPF UI (net10.0-windows)
│       ├── ViewModels/              # MainViewModel
│       └── Views/                   # MainWindow.xaml
├── tests/
│   └── GitHubManager.Core.Tests/    # xUnit tests
└── docs/plans/                      # Design documents
```

### Key Components

| Component | Purpose |
|-----------|---------|
| `RepositoryService` | Discovers Git repos recursively; executes `git pull` via LibGit2Sharp |
| `SettingsService` | Persists root folder path to `%APPDATA%\GitHubManager\settings.json` |
| `LoggerService` | Serilog wrapper writing to `logs/gitautopull-.txt` |
| `MainViewModel` | MVVM view model coordinating UI and services |

## Testing

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Configuration

Settings are stored in `%APPDATA%\GitHubManager\settings.json`:

```json
{
  "RootFolderPath": "C:\\Users\\You\\Source\\Repos"
}
```

Logs are written to `%APPDATA%\GitHubManager\logs\gitautopull-<date>.txt`.

## Dependencies

| Package | Purpose |
|---------|---------|
| `LibGit2Sharp` | Git operations (pull, branch detection) |
| `CommunityToolkit.Mvvm` | MVVM helpers (`[ObservableProperty]`, `[RelayCommand]`) |
| `Serilog.Sinks.File` | Structured logging to rolling files |

## Building for Distribution

```bash
# Publish self-contained single-file executable
dotnet publish src/GitHubManager.Wpf -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish
```

Output: `publish/GitHubManager.Wpf.exe` (~60 MB)

## License

MIT License — see [LICENSE](LICENSE) for details.

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feat/amazing-feature`)
3. Commit changes (`git commit -m 'feat: add amazing feature'`)
4. Push to branch (`git push origin feat/amazing-feature`)
5. Open a Pull Request

See [AGENTS.md](AGENTS.md) for coding conventions and contribution guidelines.
