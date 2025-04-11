# Cadmus NDP Books

- [Cadmus models reference](https://myrmex.github.io/overview/cadmus/dev/models/)
- [Cadmus bricks playground](https://cadmus-bricks.fusi-soft.com/)
- [Cadmus NDP FRAC](https://github.com/vedph/cadmus-ndp-frac)
- [Cadmus NDP Drawings](https://github.com/vedph/cadmus-ndp-drawings)

In what follows:

- 🟢 marks a [general](https://vedph.github.io/cadmus-doc/models/shared.html#general) or bibliographic part.
- 📖 marks a [codicology](https://vedph.github.io/cadmus-doc/models/shared.html#codicology) part.
- 🪨 marks an [epigraphy](https://vedph.github.io/cadmus-doc/models/shared.html#epigraphy) part.
- ⭐ marks a new part. The star is used once, even when that part is then reused in other items. If a part marked with a star has a link to documentation, this means that I have already implemented it as I could do this in advance for generic parts. All the other parts are still to be implemented.
- ⚠️ marks an area where the model must still be defined with a discussion.

```mermaid
graph LR;

EDITION --> general
general --> metadata
general --> external-ids
general --> chronotopes:prn
general --> chronotopes:pub
general --> pin-links:auth
general --> pin-links:ed
general --> categories:types
EDITION --> content
content --> print-fonts
content --> print-layout
content --> epi_signs
content --> figurative-plan
content --> note:inc
content --> note:col
EDITION --> editorial
editorial --> note
editorial --> ext-bibliography
```

```mermaid
graph LR;

INSTANCE --> general
general --> metadata
general --> external-ids
general --> cod_shelfmarks
INSTANCE --> material
material --> cod_bindings
material --> measurements
material --> states
general --> categories:edits
INSTANCE --> content
content --> print-fonts
content --> print-layout
content --> figurative-plan-impl
INSTANCE --> history
history --> events
history --> cod_edits
history --> figurative-edits?
INSTANCE --> editorial
editorial --> note
editorial --> ext-bibliography
```

## New Parts

### PrintFontsPart

- ⭐ `fonts` (`PrintFont[]`):
  - `eid` (`string`)
  - `family`\* (`string`): a descriptive ID like "R13" for the font family.
  - `sections` (`string[]` 📚 `print-layout-sections`, fieldset: title, body, comment, proem, other): the section(s) where the font is used.
  - `features` (`string[]` 📚 `print-layout-font-features` flags, features of the font, especially useful when the family can't be specified: uppercase, lowercase, Roman, Gothic, Italic, Hebrew, Greek, Glagolitic, etc.)
  - `ids` ([AssertedCompositeId[]](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-ids)): external identifiers for the font.
  - `note` (`string`)

### PrintLayoutPart

Description of the print layout.

- ⭐ `PrintLayoutPart`:
  - `sheetFormats` (`string[]` 📚 `print-layout-formats`: folio (2º), quarto (4º), octavo (8º), duodecimo (12º), duodecimo large (12º l), sextodecimo (16º), octodecimo (18º), vigesimo-quarto (24º), trigesimo-secundo (32º), other)
  - `counts` (`DecoratedCount[]` 📚 `print-layout-counts`: sheets, columns, single-sheet (carte di tavola)): counts for columns, sheets, etc.
  - `collation` (`string`, a formula to be formalized, e.g. `[i–iii]8 χ6 a10 b8 c-e10 f8 g10 h-i8 l10 m-n8 o-r10 s6; 2a-2g10 2h12 2l-2m10 2o6; A8 B-H10⁰ I6 L12`, `&8 a-i8 k6 l-r8 2a-2m8 2n4 A6 B8 C-L6 (L6 bianca)`, `π10 a-z8 &8 [con]8 [rum]8 A8 B6 C-I8 K6 L8`, etc.). The basis is <https://norme.iccu.sbn.it/index.php?title=Guida_antico/Appendici/Appendice_C>.
  - `features` (`string[]` 📚): various relevant features in layout like e.g. drop caps, framed text, etc.
  - `note` (`string`)

### FigurativePlanPart

Figurative plan.

- ⭐ `FigurativePlanPart`:
  - `artists` ([AssertedCompositeId[]](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-ids)): artists identifiers, from external or internal resources, or even simple arbitrary names for unindentified artists.
  - `techniques` (`string[]` 📚 `fig-plan-techniques`: copper engraving, woodcut, lithograph, etching, other).
  - `items` (`FigPlanItem[]`): ordered list of items (illustrations, initials, etc.):
    - `eid` (`string`): a conventional human-friendly ID.
    - `type` (`string` 📚 `fig-plan-types`: illustration, initial, scheme, diagram, frieze): type.
    - `citation` (`string`): this is a cross-project citation created according to some convention to link the figurative item to a textual passage.
  - `description` (`string`)
  - `features` (`string[]` 📚 `fig-plan-features`): any set of relevant features tagged for the plan.

### FigurativePlanImplPart

Implementation of a figurative plan.

- ⭐ `FigurativePlanImplPart`:
  - `complete` (`boolean`)
  - `techniques` (`string[]`) for override.
  - `items` (`FigPlanItemImpl[]`):
    - `id`\* (`string`): the ID of the corresponding figurative plan item, or a new one if added in this instance.
    - `location`\* (`string`): the page location.
    - `change`\* (`string`: 📚 `fig-plan-impl-changes`: none, add, delete, replace, reuse, change, misuse)
    - `features` (`string[]` 📚 `fig-plan-impl-item-features`: original block change, frame added, frame removed, frame changed, other): any relevant features of the implemented item, e.g. a frame.
    - `blockState`\* (`string` 📚 `fig-plan-impl-block-states`: fine, good, fair, damaged): the state of the woodblock used to print this item.
    - `blockStateDsc` (`string`): a free textual description of the woodblock state.
    - `position`\* (`string` 📚 `fig-plan-impl-positions`: in-text, upper margin, lower margin, full page, antiporta/frontispiece, single-sheet prints (carta di tavola)): the relative position of the item in the page.
    - `size` ([PhysicalSize](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-mat-physical-size/README.md))
    - `labels` (`FigPlanLabel[]`): the label types found in the item: e.g. a legend for the whole image, or a character name on a character in the image, etc.:
      - `type` (`string` 📚 `fig-plan-impl-labels`: legend, topographic indication, character name, inscription)
      - `fonts` (`PrintFont[]`)
    - `labelDsc` (`string`): a free textual description of image label(s).
    - `iconography` (`FigIconography`):
      - `subjects` (`string[]` 📚 `fig-plan-impl-subjects`): macrosoggetti.
      - `keywords` (`Keyword[]`):
        - `language` (`string`)
        - `value` (`string`)
      - `description` (`string`)
      - `citations` (`string[]`): any number of cross-project citation created according to some convention to link the figurative item to a textual passage.
      - `relatedIds` ([AssertedCompositeId[]](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-ids)): IDs of related entities, whatever their type (persons, manuscripts, etc.).
  - `description` (`string`)
  - `features` (`string[]` 📚 `fig-plan-impl-features`: centre, frame, initial, frieze)

## PrintEdition Item

The print edition is an abstraction, defined from at least 1 print instance.

- general:
  - 🟢 [MetadataPart](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md)
  - 🟢 [ExternalIdsPart](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md)
  - 🟢 [ChronotopesPart:prn](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md) for printed
  - 🟢 [ChronotopesPart:pub](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md) for published
  - 🟢 [PinLinksPart](https://github.com/vedph/cadmus-general/blob/master/docs/pin-links.md)`:auth`: authors
  - 🟢 [PinLinksPart](https://github.com/vedph/cadmus-general/blob/master/docs/pin-links.md)`:ed`: editors
  - 🟢 [CategoriesPart:type](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md)

- content:
  - ⭐ [PrintLayoutPart](#printlayoutpart)
  - 🪨 [EPI EpiSignsPart](https://github.com/vedph/cadmus-epigraphy/blob/master/docs/epi-signs.md)
  - 🟢 [FigurativePlanPart](#figurativeplanpart)
  - 🟢 [NotePart:inc](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for incipit
  - 🟢 [NotePart:col](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for colophon

- editorial:
  - 🟢 [NotePart](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for generic note
  - 🟢 [ExtBibliographyPart](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md)

## PrintInstance Item

- general:
  - 🟢 [MetadataPart](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md)
  - 🟢 [ExternalIdsPart](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md)
  - 📖 [COD shelfmarks](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-shelfmarks.md)

- material:
  - 📖 [COD bindings](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-bindings.md)
  - 🟢 [PhysicalMeasurementsPart](https://github.com/vedph/cadmus-general/blob/master/docs/physical-measurements.md)
  - 🟢 [PhysicalStatesPart](https://github.com/vedph/cadmus-general/blob/master/docs/physical-states.md)

- content:
  - ⭐ [PrintLayoutPart](#printlayoutpart) for overriding
  - ⭐ [FigurativePlanImplPart](#figurativeplanimplpart)
  - 🟢 [CategoriesPart:edits](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md): postille

- history:
  - 🟢 [HistoricalEventsPart](https://github.com/vedph/cadmus-general/blob/master/docs/historical-events.md)
  - 📖 [COD CodEditsPart](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-edits.md)

- editorial:
  - 🟢 [NotePart](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for generic note
  - 🟢 [ExtBibliographyPart](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md)
