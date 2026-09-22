# NuGet Package Upgrade

## Strategy
Upgrade unified package versions through `build/dependencies.props` and explicit project overrides; use build errors to locate unexpected breaks.

## Preferences
- **Flow Mode**: Automatic
- **Commit Strategy**: After Each Task
- **Scope**: All projects in `CronScheduler.sln`
- **Packages**: Every direct NuGet package reference discovered in the solution
- **Exclusions**: Auto-referenced framework packages such as `NETStandard.Library`
- **Version Policy**: Latest stable version supported by each target framework; exclude prerelease versions
- **Assessment Mode**: Quick API-diff assessment; use a full semantic scan only when needed

## Decisions
- Use every unified recommended version from assessment; no project exclusions or version overrides are required.
- Use Microsoft.Extensions 10.0.12 for net10.0, net8.0, and netstandard2.0 as recommended by the assessment.
- Keep packages already current: Bet.Extensions.Options 4.0.1, Cronos 0.13.0, Microsoft.AspNetCore.Hosting.Abstractions 2.3.13, Moq 4.20.72, and xunit.runner.visualstudio 4.0.0.
- Apply shared versions through `build/dependencies.props`; repository does not use NuGet Central Package Management.

## Custom Instructions
<!-- Task-specific overrides: "For {taskId}: {instruction}" -->

## Source Control
- **Source Branch**: `upgrade-dotnet-10`
- **Working Branch**: `upgrade-nuget-packages`
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)
