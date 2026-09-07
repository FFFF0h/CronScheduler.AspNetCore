# 02-upgrade-solution: Upgrade all projects and compatibility dependencies

Upgrade `CronScheduler.Extensions`, `CronScheduler.AspNetCore`, `CronSchedulerApp`, `CronSchedulerWorker`, and `CronScheduler.UnitTest` together to .NET 10 while preserving any intentional .NET Standard compatibility only where the project contract requires it. Apply the 15 recommended package upgrades, remove framework-included references, replace or remove the two incompatible package occurrences, and address the deprecated xUnit package.

Resolve the assessment's source-incompatible and behavioral API findings inline across libraries, the Razor Pages application, Worker Service, and tests. Research package consumers and affected APIs before editing, with particular attention to ASP.NET Core/EF Core packages, Worker hosting behavior, and test assertions affected by runtime behavior changes.

**Done when**: All five projects target their confirmed frameworks, restore succeeds without incompatible or deprecated direct package references, and all required source changes compile without warnings.
