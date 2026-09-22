# Package Version Upgrade Progress

## Changes

- Updated shared ASP.NET Core, Entity Framework Core, and Microsoft.Extensions versions from 10.0.11 to 10.0.12 in `build/dependencies.props`.
- Unified Microsoft.Extensions 10.0.12 across net10.0, net8.0, and netstandard2.0 based on assessment compatibility results.
- Updated Microsoft.NET.Test.Sdk from 18.9.0 to 18.10.1.
- Updated xunit.v3 from 4.0.0 to 4.0.1.
- Updated Microsoft.SourceLink.GitHub from 1.1.1/10.0.400 overrides to 10.0.401 across all projects.
- Kept packages already current: Bet.Extensions.Options 4.0.1, Cronos 0.13.0, Microsoft.AspNetCore.Hosting.Abstractions 2.3.13, Moq 4.20.72, and xunit.runner.visualstudio 4.0.0.

## Validation

- `dotnet restore CronScheduler.sln`: passed without warnings.
- `dotnet list CronScheduler.sln package --outdated`: no direct package updates available for any project.
- `git diff --check`: passed.

## Issues Resolved

- Removed the former 8.x Microsoft.Extensions range after assessment confirmed the unified 10.0.12 version supports all target frameworks.
- Preserved project-file BOM encoding by reverting a broad text replacement and reapplying focused XML patches.
