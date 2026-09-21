# Particles — rules for AI sessions

## RELEASE BRANCH RULE (highest priority)

New work happens on the repository's **default branch**, which is the release branch for the FlexSim line you are working in (`2026.0`, `2027.0`, `2027.1`). **There is no `main` branch: it was deleted 2026-09-17.** Each release branch is now independent: it is both where work lands and what installers are built from. Before committing, pushing, or building a release, confirm the checked-out branch matches the FlexSim version of the folder you're in and the module version's line (`26.0.x` → `2026.0`). If they don't match, stop and ask. A release is never built from a detached HEAD, a dirty tree, or a mismatched branch.

For what the module is, how to build it and how it is organised, see `README.md`.

## Documentation: every module has a manual

Every PracSim module has online documentation, so every module keeps a `manual/` folder:
`README.md` (how the manual must look), `manual.yml`, `index.md`, pages and `images/`. Read
`manual/README.md` before writing or changing documentation. The manual is published to
pracsimsolutions.com for each FlexSim release line and is not installed with the module. When a
change alters what a user sees or can do, update the manual in the same change. Only manual content
belongs in `manual/`: never publishing tools or other file types.
