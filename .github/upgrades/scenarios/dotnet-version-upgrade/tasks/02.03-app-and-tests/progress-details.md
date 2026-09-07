# Progress: Upgrade Razor Pages application and tests

## Changes

- Retargeted `CronSchedulerApp` and `CronScheduler.UnitTest` to `net10.0`.
- Updated ASP.NET Core, EF Core, HTTP resilience, TestHost, Microsoft.NET.Test.Sdk, xUnit v3, and Visual Studio runner package versions.
- Removed unsupported Visual Studio container tooling while preserving existing Docker assets.
- Removed `Bet.Extensions.Testing`, which introduced xUnit v2 transitively, and replaced its test logging helpers with built-in `LoggerFactory` and debug logging.
- Configured xUnit v3 for Microsoft Testing Platform and added `global.json` to select the .NET 10 SDK and MTP test runner.
- Migrated functional tests from deprecated `IWebHost`/`WebHostBuilder`/`TestServer(IWebHostBuilder)` patterns to generic `IHost`, `UseTestServer`, and `GetTestClient`.
- Updated asynchronous test operations to propagate `TestContext.Current.CancellationToken`.
- Excluded the legacy `IWebHost` startup-job extension on .NET 10 so the modern `IHost` extension is unambiguous.
- Simplified `TestStartup` by removing an unused logger dependency that could not be resolved during modern Startup activation.

## Validation

- `dotnet build test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj`: succeeded with zero warnings.
- `dotnet msbuild test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj -t:Test -v:minimal`: 13 total, 13 succeeded, 0 failed, 0 skipped.
- `dotnet build CronScheduler.sln`: succeeded with zero warnings.
- `dotnet list test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj package --include-transitive`: confirms only xUnit v3 packages remain; xUnit v2 and `Bet.Extensions.Testing` are absent.
- `dotnet list src/CronSchedulerApp/CronSchedulerApp.csproj package --vulnerable --include-transitive`: no known vulnerable packages.

## Issues Resolved

- Resolved duplicate `FactAttribute` and ambiguous `ITestOutputHelper` errors caused by mixed xUnit v2/v3 dependencies.
- Resolved .NET 10 startup-job extension ambiguity between legacy `IWebHost` and modern `IHost` APIs.
- Resolved ASP.NET Core hosting deprecation warnings and xUnit v3 cancellation analyzer warnings.
- `dotnet test` routing through the SDK still reported zero tests despite the MTP runner configuration; direct invocation of the imported Microsoft Testing Platform MSBuild `Test` target successfully ran all 13 tests and is the validated command for this task.
