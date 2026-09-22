# NuGet Package Upgrade Plan

## Overview

**Target**: Upgrade every direct NuGet package in `CronScheduler.sln` to the latest stable version compatible with its target frameworks.
**Scope**: Five projects with shared version declarations in `build/dependencies.props`; no source-breaking API changes or version divergence detected.

## Tasks

### 01-upgrade-package-versions: Upgrade shared package versions

Update shared package declarations to the unified versions recommended by the assessment. Preserve packages already at their latest supported version and retain the existing conditional Microsoft.Extensions policy for .NET 8 and .NET Standard 2.0 consumers. Reference the package API reports under `apidiff/`; no source migrations are expected.

**Done when**: Every direct package resolves to its recommended stable version for each supported target framework and package restore succeeds without warnings.

---

### 02-validate-solution: Validate upgraded solution

Build all target frameworks, run the focused unit test project, inspect resolved direct and transitive packages for downgrade/vulnerability warnings, and fix any build or runtime-test regressions surfaced by the upgrades.

**Done when**: The solution builds warning-free, all unit tests pass, and package inventory confirms the intended versions with no reported vulnerabilities.
