# 02.03-app-and-tests: Upgrade Razor Pages application and tests

# 02.03-app-and-tests: Upgrade Razor Pages application and tests

Replace the Razor Pages application's and xUnit test project's targets with `net10.0`. Upgrade ASP.NET Core, EF Core, HTTP resilience, and TestHost packages to `10.0.11`; remove unsupported Visual Studio container tooling from the application; and replace deprecated xUnit v2 references with the supported xUnit v3 package line.

Resolve compile and behavioral compatibility findings in the Razor Pages application and tests, especially legacy IWebHost/WebHostBuilder setup, EF Core identity context construction, HTTP content reads, and startup/exception handling. Keep test changes within this subtask so the solution does not remain broken between task boundaries.

## Research Starting Points
- Projects: `src/CronSchedulerApp/CronSchedulerApp.csproj`, `test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj`
- Central versions: `build/dependencies.props`
- App hotspots: `Controllers/HomeController.cs`, `Data/ApplicationDbContext.cs`, `Services/TorahService.cs`, `Jobs/Startup/TestStartupJob.cs`, `Program.cs`
- Test hotspots: `StartupJobFuncTests.cs`, `SchedulerFuncTests.cs`, `SchedulerRegistrationTests.cs`, `SchedulerServiceTests.cs`, `TestStartupJob.cs`

**Done when**: Both projects restore and build warning-free on `net10.0`, no unsupported/deprecated direct package references remain, all 13 tests pass, and the complete solution builds without warnings.

## Research Findings

- Both `TargetFramework` properties are local and should be replaced in place with `net10.0`.
- ASP.NET Core, EF Core, HTTP resilience, and TestHost versions are inherited from `build/dependencies.props`; the assessment-supported version is 10.0.11.
- No supported net10.0 release exists for `Microsoft.VisualStudio.Azure.Containers.Tools.Targets`, so remove the application's direct reference while preserving its Docker assets.
- The deprecated direct `xunit` 2.9.3 reference should become `xunit.v3` 4.0.0; align the Visual Studio runner to 4.0.0 and the supported test SDK to 18.9.0, then validate compatibility with Bet.Extensions.Testing.
- Existing application and test API findings are potential compatibility signals. Apply package/TFM changes first, then use compiler and test failures to identify required source edits rather than rewriting valid APIs speculatively.
- `Bet.Extensions.Testing` 4.0.1 transitively introduced xUnit v2 alongside xUnit v3. Its only usage was test-output logging, so it was removed and replaced with built-in logging.
- xUnit v3 on the .NET 10 SDK uses Microsoft Testing Platform. The repository therefore needs a `global.json` test-runner selection plus xUnit's MTP entry-point properties in the test project.
- Functional tests used deprecated `WebHostBuilder` and `TestServer(IWebHostBuilder)` APIs. They can use generic `IHost`, `UseTestServer`, and `GetTestClient` without changing coverage or behavior.
- xUnit v3 analyzer guidance requires asynchronous test operations to propagate `TestContext.Current.CancellationToken`.

