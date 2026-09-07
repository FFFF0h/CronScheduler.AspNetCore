# Cronos 0.13.0 Upgrade

## Summary

Cronos was upgraded from 0.8.x to exactly 0.13.0 across all `CronScheduler.Extensions` target frameworks. The scheduler now exposes deterministic jitter and previous-occurrence lookup while preserving existing five-field and six-field schedules.

## Implementation

- Added `SchedulerOptions.CronJitterSeed` for deterministic `H`-based schedule jitter.
- Passed custom job option seeds through `SchedulerBuilder`.
- Selected the Cronos seeded parse overload only when a seed is configured, preserving existing behavior by default.
- Added `SchedulerTaskWrapper.GetPreviousOccurrence` using each job's configured time zone.
- Updated Razor Pages and Worker sample configuration to demonstrate jitter.
- Updated the root README, both sample READMEs, migration guide, and public XML documentation.

## Validation

- `dotnet build CronScheduler.sln --no-incremental`: succeeded with zero warnings and errors.
- `dotnet msbuild test/CronScheduler.UnitTest/CronScheduler.UnitTest.csproj -t:Test -v:minimal`: 15 tests passed, 0 failed, 0 skipped.
- Cronos resolves to 0.13.0 for net10.0, net8.0, and netstandard2.0.
- No vulnerable or deprecated packages were reported.
- Remaining outdated-package output is intentional: Microsoft.Extensions 8.x supports retained net8.0/netstandard2.0 targets, while the SourceLink result reflects SDK versioning rather than an applicable package update.
