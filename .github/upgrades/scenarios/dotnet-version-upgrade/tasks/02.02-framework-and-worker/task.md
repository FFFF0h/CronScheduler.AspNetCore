# 02.02-framework-and-worker: Upgrade ASP.NET Core library and Worker Service

# 02.02-framework-and-worker: Upgrade ASP.NET Core library and Worker Service

Add `net10.0` as the first target of `CronScheduler.AspNetCore` while preserving `net8.0` and `netstandard2.0`, and replace the Worker Service target with `net10.0`. Remove the unsupported Visual Studio container tooling package from the Worker, update Microsoft.Extensions.Hosting to the .NET 10 line, and preserve the existing BackgroundService-based worker architecture.

## Research Starting Points
- Projects: `src/CronScheduler.AspNetCore/CronScheduler.AspNetCore.csproj`, `src/CronSchedulerWorker/CronSchedulerWorker.csproj`
- Central versions: `build/dependencies.props`
- API hotspots: `DependencyInjection/StartupJobWebHostExtensions.cs`, `src/CronSchedulerWorker/TestStartupJob.cs`
- Project dependency: both projects consume `CronScheduler.Extensions`.

**Done when**: The ASP.NET Core library builds warning-free for all retained targets, the Worker builds warning-free for `net10.0`, unsupported container tooling is absent, and the complete solution remains buildable.

## Research Findings

- Both target framework properties are defined directly in their project files; the ASP.NET Core library keeps three targets while the Worker replaces net8.0 with net10.0.
- The library's net10/net8 targets use `Microsoft.AspNetCore.App`; only netstandard2.0 retains the legacy hosting abstractions package.
- `Microsoft.Extensions.Hosting` receives version 10.0.11 through the target-specific central `ExtensionsVersion` override added by the foundation subtask.
- `Microsoft.VisualStudio.Azure.Containers.Tools.Targets` has no supported net10.0 version and can be removed without changing the Worker's existing `BackgroundService` implementation or Dockerfile.
- The assessed IWebHost and TimeSpan call sites are retained unless the target builds demonstrate a concrete incompatibility.

