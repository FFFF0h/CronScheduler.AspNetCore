# NuGet package upgrade assessment

_Mode: **quick assessment** — package API diffs only; no per-project source scan was run._

## Recommended versions

- **Bet.Extensions.Options**: **4.0.1** (unified across 1 project(s)).
- **Cronos**: **0.13.0** (unified across 1 project(s)).
- **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.AspNetCore.Hosting.Abstractions**: **2.3.13** (unified across 1 project(s)).
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.AspNetCore.Identity.UI**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.AspNetCore.TestHost**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.Relational**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.Sqlite**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.SqlServer**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.Tools**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.DependencyInjection**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.Hosting**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.Hosting.Abstractions**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.Http.Polly**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.Logging.Abstractions**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.Extensions.Options.ConfigurationExtensions**: **10.0.12** (unified across 1 project(s)).
- **Microsoft.NET.Test.Sdk**: **18.10.1** (unified across 1 project(s)).
- **Microsoft.SourceLink.GitHub**: **10.0.401** (unified across 5 project(s)).
- **Moq**: **4.20.72** (unified across 1 project(s)).
- **xunit.runner.visualstudio**: **4.0.0** (unified across 1 project(s)).
- **xunit.v3**: **4.0.1** (unified across 1 project(s)).

## Public API changes

> **Types moved (namespace changed) are not removals.** A moved type keeps its name and members;
> the fix is a `using`-directive change, not a rewrite. Do not treat a moved type as deleted.

- **Microsoft.Extensions.DependencyInjection**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.DependencyInjection.apidiff.md`](apidiff/Microsoft.Extensions.DependencyInjection.apidiff.md).
- **Microsoft.Extensions.Hosting.Abstractions**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.Hosting.Abstractions.apidiff.md`](apidiff/Microsoft.Extensions.Hosting.Abstractions.apidiff.md).
- **Microsoft.Extensions.Logging.Abstractions**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.Logging.Abstractions.apidiff.md`](apidiff/Microsoft.Extensions.Logging.Abstractions.apidiff.md).
- **Microsoft.Extensions.Options.ConfigurationExtensions**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.Options.ConfigurationExtensions.apidiff.md`](apidiff/Microsoft.Extensions.Options.ConfigurationExtensions.apidiff.md).
- **Microsoft.SourceLink.GitHub**: no source-breaking public API changes detected — see [`apidiff/Microsoft.SourceLink.GitHub.apidiff.md`](apidiff/Microsoft.SourceLink.GitHub.apidiff.md).
- **Microsoft.Extensions.Hosting**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.Hosting.apidiff.md`](apidiff/Microsoft.Extensions.Hosting.apidiff.md).
- **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore**: no source-breaking public API changes detected — see [`apidiff/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.apidiff.md`](apidiff/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.apidiff.md).
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: no source-breaking public API changes detected — see [`apidiff/Microsoft.AspNetCore.Identity.EntityFrameworkCore.apidiff.md`](apidiff/Microsoft.AspNetCore.Identity.EntityFrameworkCore.apidiff.md).
- **Microsoft.AspNetCore.Identity.UI**: no source-breaking public API changes detected — see [`apidiff/Microsoft.AspNetCore.Identity.UI.apidiff.md`](apidiff/Microsoft.AspNetCore.Identity.UI.apidiff.md).
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson**: no source-breaking public API changes detected — see [`apidiff/Microsoft.AspNetCore.Mvc.NewtonsoftJson.apidiff.md`](apidiff/Microsoft.AspNetCore.Mvc.NewtonsoftJson.apidiff.md).
- **Microsoft.EntityFrameworkCore.Relational**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Relational.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Relational.apidiff.md).
- **Microsoft.EntityFrameworkCore.Sqlite**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Sqlite.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Sqlite.apidiff.md).
- **Microsoft.EntityFrameworkCore.SqlServer**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.SqlServer.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.SqlServer.apidiff.md).
- **Microsoft.EntityFrameworkCore.Tools**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md).
- **Microsoft.Extensions.Http.Polly**: no source-breaking public API changes detected — see [`apidiff/Microsoft.Extensions.Http.Polly.apidiff.md`](apidiff/Microsoft.Extensions.Http.Polly.apidiff.md).
- **Microsoft.AspNetCore.TestHost**: no source-breaking public API changes detected — see [`apidiff/Microsoft.AspNetCore.TestHost.apidiff.md`](apidiff/Microsoft.AspNetCore.TestHost.apidiff.md).
- **Microsoft.NET.Test.Sdk**: no source-breaking public API changes detected — see [`apidiff/Microsoft.NET.Test.Sdk.apidiff.md`](apidiff/Microsoft.NET.Test.Sdk.apidiff.md).
- **xunit.v3**: no source-breaking public API changes detected — see [`apidiff/xunit.v3.apidiff.md`](apidiff/xunit.v3.apidiff.md).

## Breaking-change findings

- Version divergence findings (Pkg.0003): 0
- Requested-version-unsupported findings (Pkg.0002): 0

- Quick mode does not scan source, so there are no per-line `PkgApi` usage findings. Review the
  per-package API diffs above and rely on build errors during execution to pinpoint affected code.
- A full code scan can locate the exact source location of every breaking-change usage across the repo.
  It is opt-in and slower — re-run the assessment with `fullScan=true` only if the user requests it.

## Next steps

1. Proceed to planning to triage the API changes above and plan the code fixes (if any).

