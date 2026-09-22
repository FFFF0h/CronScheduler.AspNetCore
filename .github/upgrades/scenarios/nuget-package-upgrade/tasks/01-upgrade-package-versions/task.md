# 01-upgrade-package-versions: Upgrade shared package versions

Update shared package declarations and explicit project overrides to the unified versions recommended by the assessment. Preserve packages already at their latest supported version. Reference the package API reports under `apidiff/`; no source migrations are expected.

**Done when**: Every direct package resolves to its recommended stable version for each supported target framework and package restore succeeds without warnings.

## Research Findings

- All five SDK-style projects import shared package policy from `build/dependencies.props`; NuGet Central Package Management is not enabled.
- Shared upgrades required: ASP.NET Core/EF Core/Microsoft.Extensions net10.0 packages 10.0.11 → 10.0.12, Microsoft.NET.Test.Sdk 18.9.0 → 18.10.1, xunit.v3 4.0.0 → 4.0.1, and Microsoft.SourceLink.GitHub → 10.0.401.
- Assessment confirms Microsoft.Extensions 10.0.12 supports net10.0, net8.0, and netstandard2.0, so the former 8.x compatibility split can be removed.
- Bet.Extensions.Options 4.0.1, Cronos 0.13.0, Microsoft.AspNetCore.Hosting.Abstractions 2.3.13, Moq 4.20.72, and xunit.runner.visualstudio 4.0.0 are already current.
- Quick API diffs found no source-breaking changes and no version divergence; build-driven verification is sufficient.
- Project-level Source Link and Microsoft.Extensions overrides take precedence over shared metadata and must be updated together with `build/dependencies.props`.
