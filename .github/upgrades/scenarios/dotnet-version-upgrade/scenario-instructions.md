# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Upgrade Options
**Source**: .github/upgrades/scenarios/dotnet-version-upgrade/upgrade-options.md

### Strategy
- Upgrade Strategy: All-at-Once

### Compatibility
- Unsupported Packages: Resolve Inline (2 incompatible package occurrences)
- Unsupported API Handling: Fix Inline

## Strategy
**Selected**: All-at-Once
**Rationale**: Five modern SDK-style projects form a shallow three-level dependency graph, with two incompatible package occurrences suitable for one coordinated upgrade.

### Execution Constraints
- Update all project target frameworks and project-file conditions in one atomic operation.
- Update package references across all projects before restoring dependencies.
- Resolve incompatible packages and framework API changes inline without deferred stubs.
- Build the complete solution warning-free after the atomic upgrade.
- Run affected tests only after the upgraded solution builds successfully.

## Build Tool Decisions
- **CronScheduler.sln**: `dotnet build` (all projects are SDK-style and target modern .NET/.NET Standard without Visual Studio-only build features)

## User Preferences

### Technical Preferences
- Upgrade Cronos specifically from 0.8.4 to 0.13.0 and adopt relevant new Cronos capabilities rather than making a version-only change.
- Update all affected documentation, with particular attention to the root `README.md`.
