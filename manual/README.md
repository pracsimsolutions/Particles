# Writing this manual

This folder is the user manual for this module. It is published to pracsimsolutions.com by the
maintainers, one copy per FlexSim release line: the `2026.0` branch is line 26.0, `2027.0` is
line 27.0. **This README is for the people who write the manual. It is never published.**

## What belongs here

Only manual content: markdown pages, `manual.yml`, and images. Nothing else. No scripts, HTML,
PDFs, build output or tooling; the publisher rejects any other file type. The manual describes
how the module behaves on this branch's release line, so a fix lands on the branch it is true for.

## Layout

```
manual/
  README.md        this file (never published)
  manual.yml       module slug, title, and the section list (required)
  index.md         the landing page (required)
  whats-new.md     release notes, newest first
  how-to/          task guides, one page per task (optional)
  objects/         one page per 3D object or system (optional)
  panels/          one page per property panel (optional)
  api/             one page per FlexScript class, named after the class (optional)
  images/          every screenshot, flat, with kebab-case names
```

Use only the folders the module needs. Folder names are only for tidiness: a page's place in the
navigation comes from its front matter (below), not from its folder.

## manual.yml

```yaml
module: particles          # the product slug: lowercase, one word, must match the website
title: PracSim Particles   # shown at the top of the navigation
sections:                  # optional; groups pages in the left-hand tree
  - id: panels
    title: Property Panels
  - id: api
    title: FlexScript API Reference
```

A page belongs to a section when its front matter says `section: <id>`. Pages with no section
appear at the top level of the module. The order of `sections` is the order shown.

## Pages

Every page starts with front matter:

```markdown
---
title: Corridor
summary: One sentence, shown under the title and in search results.
section: objects
order: 2
---
```

- `title` is required. `summary` is strongly recommended; quote it if it contains a colon.
- `order` is a number; pages sort by it, then by title. Put `whats-new.md` last (`order: 99`).
- Do not start the body with a `#` heading. The title comes from the front matter, so start
  with text or a `##` heading.
- Links between pages are relative and end in `.md`, and they are case-sensitive:
  `[Junction](junction.md)`, `[Emitter](../api/Particles.Emitter.md)`.
- Images are relative files inside this folder: `![Corridor panel](images/corridor-panel.png)`
  (or `../images/...` from a subfolder). Always write alt text. External images are blocked.
  Allowed types: png, jpg, gif, webp, svg (an svg may not contain scripts).
- Raw HTML is not rendered. Use markdown tables and lists instead.

## Callouts and code

Callouts use GitHub alert syntax and become styled boxes:

```markdown
> [!NOTE]
> Extra context the reader can skip.
```

Kinds: `NOTE`, `TIP`, `IMPORTANT`, `WARNING`, `CAUTION`.

FlexScript code goes in a fence tagged `flexscript` so it is highlighted with FlexSim's own colors:

````markdown
```flexscript
Particles.Emitter e = Model.find("ParticleEmitter1");
e.gravity.z = -9.8;
```
````

## Style

- Write for someone using the module, in plain sentences. Describe what they see and can do.
- **Do not write version numbers in a page** (except in `whats-new.md`). The manual is already
  versioned by release line, and a number in prose is wrong by the next patch.
- Avoid em dashes. Use commas, colons, periods or parentheses.
- Do not name specific customers or companies.
- One idea per page. Prefer several short pages to one long one.

## What's new

`whats-new.md` lists releases, newest first, one `##` heading per release with a short list of
what changed for the user. It is the one page where version numbers belong.

## What the publisher checks

Errors block publishing and are reported with the file name: a missing `manual.yml` or
`index.md`, a `module` that does not match the module being published, a page with no `title`, a
broken relative link or missing image, a `section` that is not in `manual.yml`, a file type that
is not allowed. Warnings never block: an em dash, a version number in prose, a leading `#`
heading, or an image that no page uses.

## Keeping lines in step

Docs fixes (a typo, a clearer sentence) are ordinary commits. To bring a fix to another release
line, cherry-pick or merge it like any other change. Because the manual carries no version
content, that applies cleanly.
