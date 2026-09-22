# 02-validate-solution: Validate upgraded solution

Build all target frameworks, run the focused unit test project, inspect resolved direct and transitive packages for downgrade/vulnerability warnings, and fix any build or runtime-test regressions surfaced by the upgrades.

**Done when**: The solution builds warning-free, all unit tests pass, and package inventory confirms the intended versions with no reported vulnerabilities.
