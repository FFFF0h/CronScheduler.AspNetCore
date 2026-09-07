# 01-toolchain-readiness: Verify .NET 10 prerequisites

Validate that the .NET 10 SDK is installed and compatible with any repository `global.json` configuration. Establish a clean baseline build and test result before changing target frameworks so upgrade regressions can be distinguished from existing issues.

**Done when**: The required SDK is available, repository SDK selection is compatible with .NET 10, and baseline build/test results are recorded.

## Research Findings

- .NET SDK `10.0.400` is installed and selected by `dotnet --version`.
- No repository `global.json` or repository-specific build guide was found, so no SDK pin blocks .NET 10.
- The solution contains five SDK-style projects: two class libraries, one ASP.NET Core application, one Worker Service, and one xUnit test project.
- The projects target modern .NET/.NET Standard only and have no legacy Visual Studio build features requiring full-framework MSBuild; use the IDE solution build (with `dotnet build` as the CLI fallback).
- `.github/copilot-instructions.md` is an unrelated untracked workspace file and must remain unchanged and excluded from upgrade commits.
- The initial .NET 10 SDK baseline build exposed `CS0023` in `HomeController`: `string[]#Reverse()` bound to a new in-place `void` API instead of LINQ. Direct first/last indexing preserves the intended verse range and restores compilation.

## Validation Plan

- Build `CronScheduler.sln` in the default configuration and record all warnings/errors.
- Run `CronScheduler.UnitTest` to establish the pre-upgrade test baseline.
