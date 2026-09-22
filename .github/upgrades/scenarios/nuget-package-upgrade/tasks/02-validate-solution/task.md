# 02-validate-solution: Validate upgraded solution

Build all target frameworks, run the focused unit test project, inspect resolved direct and transitive packages for downgrade/vulnerability warnings, and fix any build or runtime-test regressions surfaced by the upgrades.

**Done when**: The solution builds warning-free, all unit tests pass, and package inventory confirms the intended versions with no reported vulnerabilities.

## Research Findings

- Solution contains five SDK-style projects; `dotnet build CronScheduler.sln` is the appropriate full validation command.
- `CronScheduler.Extensions` and `CronScheduler.AspNetCore` multi-target net10.0, net8.0, and netstandard2.0; solution build must compile every target.
- Focused tests live in `test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj` and use xUnit v3 with Microsoft Testing Platform.
- Package validation requires `dotnet list ... package --outdated` for target-version confirmation and `--vulnerable --include-transitive` for advisory checks.
- Task 1 restore succeeded without warnings and found no remaining direct stable updates.
