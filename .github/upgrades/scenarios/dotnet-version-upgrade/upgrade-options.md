# Upgrade Options — CronScheduler.sln

Assessment: 5 SDK-style modern .NET projects, 3 dependency levels, 75 compatibility findings, 2 incompatible package occurrences, and 33 source-incompatible API findings.

## Strategy

### Upgrade Strategy
Five modern .NET projects form a shallow three-level graph, so one coordinated upgrade avoids temporary cross-target incompatibility.

| Value | Description |
|-------|-------------|
| **All-at-Once** (selected) | Upgrade all projects together in one atomic pass, then validate the complete solution. |
| Top-Down | Upgrade applications first and temporarily multi-target shared libraries before consolidation. |

## Compatibility

### Unsupported Packages
Assessment identified two incompatible package occurrences without compatible target-framework versions.

| Value | Description |
|-------|-------------|
| **Resolve Inline** (selected) | Research and remove or replace each incompatible package while upgrading its owning project. |
| Defer Resolution | Add minimal compilation stubs and create follow-up replacement tasks. |
| Compatibility Mode | Retain framework references for transitive or Windows-only dependencies with known runtime risk. |

### Unsupported API Handling
Assessment identified 33 source-incompatible framework API findings across all five projects.

| Value | Description |
|-------|-------------|
| **Fix Inline** (selected) | Resolve simple and complex API changes within the upgrade task, leaving no deferred stubs. |
| Defer Complex Changes | Apply simple replacements now and create resolution tasks for complex changes. |
