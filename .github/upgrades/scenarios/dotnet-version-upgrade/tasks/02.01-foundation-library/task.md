# 02.01-foundation-library: Upgrade CronScheduler.Extensions for .NET 10

# 02.01-foundation-library: Upgrade CronScheduler.Extensions for .NET 10

Add `net10.0` as the first target of `CronScheduler.Extensions` while preserving `net8.0` and `netstandard2.0` compatibility. Update the centrally imported Microsoft.Extensions package family to the assessed .NET 10-compatible line without breaking retained target frameworks. Review the two TimeSpan API findings and only change source where compilation or behavior requires it.

## Research Starting Points
- Project: `src/CronScheduler.Extensions/CronScheduler.Extensions.csproj`
- Central versions: `build/dependencies.props`
- API hotspots: `DependencyInjection/BackgroundQueuedServiceCollectionExtensions.cs`, `Internal/SchedulerHostedService.cs`
- No existing `// STUB:` markers were found.

**Done when**: All three targets (`net10.0`, `net8.0`, `netstandard2.0`) restore and build without warnings, and the complete solution remains buildable.

## Research Findings

- `TargetFrameworks` is defined directly in `CronScheduler.Extensions.csproj`; add `net10.0` first while retaining both existing targets.
- Microsoft.Extensions versions are supplied by `ExtensionsVersion` in `build/dependencies.props`, not by CPM or direct project attributes. The assessment recommends `10.0.11` for all four explicit Microsoft.Extensions references.
- The existing `TimeSpan.FromSeconds` calls use valid integral constants and require no speculative source rewrite unless the net10 build reports an error.
- The v10 Microsoft.Extensions packages must continue supporting the retained `net8.0` and `netstandard2.0` targets; validate every TFM and then the solution.

