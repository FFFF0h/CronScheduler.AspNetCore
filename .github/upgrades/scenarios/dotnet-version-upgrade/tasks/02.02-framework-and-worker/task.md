# 02.02-framework-and-worker: Upgrade ASP.NET Core library and Worker Service

# 02.02-framework-and-worker: Upgrade ASP.NET Core library and Worker Service

Add `net10.0` as the first target of `CronScheduler.AspNetCore` while preserving `net8.0` and `netstandard2.0`, and replace the Worker Service target with `net10.0`. Remove the unsupported Visual Studio container tooling package from the Worker, update Microsoft.Extensions.Hosting to the .NET 10 line, and preserve the existing BackgroundService-based worker architecture.

## Research Starting Points
- Projects: `src/CronScheduler.AspNetCore/CronScheduler.AspNetCore.csproj`, `src/CronSchedulerWorker/CronSchedulerWorker.csproj`
- Central versions: `build/dependencies.props`
- API hotspots: `DependencyInjection/StartupJobWebHostExtensions.cs`, `src/CronSchedulerWorker/TestStartupJob.cs`
- Project dependency: both projects consume `CronScheduler.Extensions`.

**Done when**: The ASP.NET Core library builds warning-free for all retained targets, the Worker builds warning-free for `net10.0`, unsupported container tooling is absent, and the complete solution remains buildable.

