# Cadmus NDP Books

- [Cadmus models reference](https://myrmex.github.io/overview/cadmus/dev/models/)
- [Cadmus bricks playground](https://cadmus-bricks.fusi-soft.com/)
- [Cadmus NDP FRAC](https://github.com/vedph/cadmus-ndp-frac)

In what follows:

- 📖 marks a [codicology](https://github.com/vedph/cadmus-doc/blob/master/docs/models/index.md#codicology) part.
- ⭐ marks a new part. The star is used once, even when that part is then reused in other items. If a part marked with a star has a link to documentation, this means that I have already implemented it as I could do this in advance for generic parts. All the other parts are still to be implemented.
- ⚠️ marks an area where the model must still be defined with a discussion.

## Items

- edition: this is an abstraction derived from 1 or more instances. Shared data could be placed here rather than repeating them for each instance.
- instance
- illustration
- frieze

## Instance Item

- 🌟 RelatedEntitiesPart:
  - entities (RelatedEntity[]):
    - type (`string` 📚)
    - roles (`string[]` 📚)
    - labels:
      - language (`string` 📚)
      - value (`string`)
    - identifiers:
      - scope (`string` 📚)
      - value (`string`)
    - note (`string`)

>This can be used for authors and editors with different roles.

- 🌟 PrintLayoutPart:
  - fonts (`string[]`? what formalism? e.g. 13R)
  - sheet format (`string` 📚) ??many
  - counts (for columns, sheets, etc.)
  - collation (`string`: ??formula)
  - features (`string[]` 📚 e.g. drop caps, framed comment...)
  - note

- 🌟 PrintContentPart??:
  - contents (`PrintContent[]`):
    - location (`string`: ??form)
    - title (`string`)
    - language (`string` 📚)
    - identifiers (`string[]`)??
    - note (`string`)

>I would suggest a higher level contents model which can be applied to all the NDP sub-projects.

- [MetadataPart](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md)
- [ChronotopesPart:prn](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md) for printed
- [ChronotopesPart:pub](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md) for published
- [ExternalIdsPart](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md)
- [NotePart:inc](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for incipit
- [NotePart:col](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for colophon
- [NotePart](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for generic note
- [ExtBibliographyPart](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md)

>If you need more on the text of incipit/colophon we have better make them base text parts of an independent item.

- Progetto illustrativo: we need to define the granularity level:
  - attribution: text
  - project: text??
  - technique: can get at least some features??
  - description: text??

Connected to this we have:

- illustrations
- initials
- friezes
- reuses: for each one:
  - type (`string` 📚)
  - location(s) (`string[]`)
  - description (`string`)
  - citations (`string[]` form??)
  - note (`string`)

## Illustration Item

- To be structured:
  - location
  - tipologia matrice
  - size
  - frame size
  - frame description
  - frame features
  - iscrizioni
  - description
  - citations
  - livello del testo??
  - contesto interno??
  - rapporti tradizione dantesca??
  - soggetto??

- [MetadataPart](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md)
- [ExternalIdsPart](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md)
- [CategoriesPart:subj](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md): "macrosoggetto".
- [IndexKeywordsPart](https://github.com/vedph/cadmus-general/blob/master/docs/index-keywords.md)
- [NotePart](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) for generic note
- [ExtBibliographyPart](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md)
- [PhysicalStatesPart](https://github.com/vedph/cadmus-general/blob/master/docs/physical-states.md)
