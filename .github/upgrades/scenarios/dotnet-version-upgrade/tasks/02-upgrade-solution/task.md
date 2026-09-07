# 02-upgrade-solution: Upgrade all projects and compatibility dependencies

Upgrade `CronScheduler.Extensions`, `CronScheduler.AspNetCore`, `CronSchedulerApp`, `CronSchedulerWorker`, and `CronScheduler.UnitTest` together to .NET 10 while preserving any intentional .NET Standard compatibility only where the project contract requires it. Apply the 15 recommended package upgrades, remove framework-included references, replace or remove the two incompatible package occurrences, and address the deprecated xUnit package.

Resolve the assessment's source-incompatible and behavioral API findings inline across libraries, the Razor Pages application, Worker Service, and tests. Research package consumers and affected APIs before editing, with particular attention to ASP.NET Core/EF Core packages, Worker hosting behavior, and test assertions affected by runtime behavior changes.

**Done when**: All five projects target their confirmed frameworks, restore succeeds without incompatible or deprecated direct package references, and all required source changes compile without warnings.

## Scope Inventory

### Projects and dependency order

1. `CronScheduler.Extensions` — foundation library; currently `netstandard2.0;net8.0`, proposed `netstandard2.0;net8.0;net10.0`.
2. `CronScheduler.AspNetCore` and `CronSchedulerWorker` — depend on Extensions; the library adds `net10.0`, while the Worker replaces `net8.0` with `net10.0`.
3. `CronSchedulerApp` and `CronScheduler.UnitTest` — top-level dependents; both replace `net8.0` with `net10.0`.

### Package actions

- Package versions are managed through imported `build/dependencies.props` updates rather than NuGet CPM.
- Set ASP.NET Core, EF Core, and Microsoft.Extensions package families to the assessed .NET 10-compatible `10.0.11` line.
- Remove `NETStandard.Library` implications by relying on SDK framework references; it is implicit rather than directly declared.
- Remove `Microsoft.VisualStudio.Azure.Containers.Tools.Targets` from App and Worker because no supported `net10.0` version is available.
- Replace deprecated `xunit` v2 with `xunit.v3` 4.0.0 and align `xunit.runner.visualstudio` to 4.0.0; verify compatibility with existing test helpers and all 13 tests.
- Keep compatible third-party packages (Cronos, Bet.Extensions, Moq) unless restore/build identifies a concrete conflict.

### API and behavioral findings

- Libraries: `TimeSpan.FromSeconds` call sites and the legacy `IWebHost` extension are assessment hotspots; compile all retained TFMs before changing code.
- Razor Pages application: inspect `HomeController`, `ApplicationDbContext`, `TorahService`, startup job code, and `Program.cs` after package/TFM updates.
- Worker Service: preserve the existing Worker/hosted-service architecture and validate its startup job delay call.
- Tests: legacy `IWebHost`/`WebHostBuilder` setup and HTTP content behavior are the primary runtime-compatibility areas.
- No `// STUB:` markers exist in affected source files, so no deferred stub-resolution work is required.

## Execution Decision

The common mandatory dependency-ordering hint applies to this five-project dependency chain. Execute as three dependency-tier subtasks while preserving the parent task's coordinated .NET 10 outcome and validating the full solution at each boundary.
