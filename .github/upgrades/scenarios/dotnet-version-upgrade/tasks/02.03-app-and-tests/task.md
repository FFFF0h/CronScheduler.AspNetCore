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

