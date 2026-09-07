## Detected Hints

### hint: multi-project-dependency-ordering
- **Status**: active
- **Priority**: MUST
- **Evidence**: Task 02 changes TFMs and significant packages across five projects in a three-level project-reference graph.
- **Detected**: During task 02 research.

### hint: large-package-replacement-batch
- **Status**: resolved
- **Priority**: SHOULD
- **Evidence**: Only two incompatible package occurrences exist and both are the same removable Visual Studio container tooling package.
- **Detected**: During task 02 research.

### hint: test-project-lifecycle
- **Status**: resolved
- **Priority**: MUST
- **Evidence**: One test project references both shared libraries; no code or references move between projects, and its TFM/framework update is included in the final dependency-tier subtask.
- **Detected**: During task 02 research.

### hint: test-framework-upgrade
- **Status**: active
- **Priority**: SHOULD
- **Evidence**: The test project directly references deprecated xUnit v2 while targeting net10.0.
- **Detected**: During task 02 research.

## Breakdown Decisions

### task: 02-upgrade-solution
- Broken into 3 subtasks based on hints: multi-project-dependency-ordering, test-framework-upgrade.
