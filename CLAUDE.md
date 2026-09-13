# Particles — rules for AI sessions

## RELEASE BRANCH RULE (highest priority)

New work happens on `main`. Every FlexSim release has its own branch named `year.release` (`2026.0`, `2027.0`, `2027.1`), and installers are built only from those branches. Before committing, pushing, or building a release, confirm the checked-out branch matches the FlexSim version of the folder you're in and the module version's line (`26.0.x` → `2026.0`). If they don't match, stop and ask. module-builder refuses builds from `main`, detached HEAD, a dirty tree, or a mismatched branch.

For what the module is, how to build it and how it is organised, see `README.md`.
