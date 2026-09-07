# .NET 10 Version Upgrade Plan

## Overview

**Target**: Upgrade CronScheduler.sln from .NET Standard 2.0/.NET 8 to .NET 10.
**Scope**: Five SDK-style projects: two libraries, an ASP.NET Core application, a Worker Service, and an xUnit test project.

### Selected Strategy
**All-at-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: Five projects, a three-level dependency graph, and two incompatible package occurrences make a coordinated modern-to-modern upgrade more efficient than temporary multi-targeting.

## Tasks

### 01-toolchain-readiness: Verify .NET 10 prerequisites

Validate that the .NET 10 SDK is installed and compatible with any repository `global.json` configuration. Establish a clean baseline build and test result before changing target frameworks so upgrade regressions can be distinguished from existing issues.

**Done when**: The required SDK is available, repository SDK selection is compatible with .NET 10, and baseline build/test results are recorded.

---

### 02-upgrade-solution: Upgrade all projects and compatibility dependencies

Upgrade `CronScheduler.Extensions`, `CronScheduler.AspNetCore`, `CronSchedulerApp`, `CronSchedulerWorker`, and `CronScheduler.UnitTest` together to .NET 10 while preserving any intentional .NET Standard compatibility only where the project contract requires it. Apply the 15 recommended package upgrades, remove framework-included references, replace or remove the two incompatible package occurrences, and address the deprecated xUnit package.

Resolve the assessment's source-incompatible and behavioral API findings inline across libraries, the Razor Pages application, Worker Service, and tests. Research package consumers and affected APIs before editing, with particular attention to ASP.NET Core/EF Core packages, Worker hosting behavior, and test assertions affected by runtime behavior changes.

**Done when**: All five projects target their confirmed frameworks, restore succeeds without incompatible or deprecated direct package references, and all required source changes compile without warnings.

---

### 03-solution-validation: Validate the upgraded solution

Build the complete solution after the atomic upgrade and run the full test suite. Resolve upgrade-related build warnings, test failures, dependency conflicts, and security findings, then record the final validation evidence and any non-blocking recommendations.

**Done when**: The solution builds with zero errors and warnings, all tests pass, no dependency conflicts remain, and the final upgrade state is documented.
