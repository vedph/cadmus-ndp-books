using System;
using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Cadmus.Mat.Bricks;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;

namespace Cadmus.NdpBooks.Parts;

/// <summary>
/// Printed book layout part.
/// <para>Tag: <c>it.vedph.ndp.print-layout</c>.</para>
/// </summary>
[Tag("it.vedph.ndp.print-layout")]
public sealed class PrintLayoutPart : PartBase
{
    /// <summary>
    /// The list of sheet formats. Usually from thesaurus
    /// <c>print-layout-formats</c>.
    /// </summary>
    public List<string>? SheetFormats { get; set; }

    /// <summary>
    /// Various counts related to the layout. Usually from thesaurus
    /// <c>print-layout-counts</c>.
    /// </summary>
    public List<DecoratedCount>? Counts { get; set; }

    /// <summary>
    /// A conventional formula expressing the layout. The basis is documented
    /// in https://norme.iccu.sbn.it/index.php?title=Guida_antico/Appendici/Appendice_C.
    /// </summary>
    public string? Formula { get; set; }

    /// <summary>
    /// Various dimensions of the layout, such as margins, etc., either derived
    /// from <see cref="Formula"/> or manually added.
    /// </summary>
    public List<PhysicalDimension>? Dimensions { get; set; }

    /// <summary>
    /// General features of the layout, such as drop caps, framed text, etc.
    /// Usually from thesaurus <c>print-layout-features</c>.
    /// </summary>
    public List<string>? Features { get; set; }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        if (SheetFormats?.Count > 0)
            builder.AddValues("sheet-format", SheetFormats);
        if (Features?.Count > 0)
            builder.AddValues("layout-feature", Features);

        if (Counts?.Count > 0)
        {
            foreach (DecoratedCount count in Counts)
                builder.AddValue($"count-{count.Id}", count.Value);
        }
        if (Dimensions?.Count > 0)
        {
            foreach (PhysicalDimension dim in Dimensions)
                builder.AddValue($"dimension-{dim.Tag}", dim.Value);
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(
        [
             new DataPinDefinition(DataPinValueType.String,
                "sheet-format",
                "The sheet format(s).",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "layout-feature",
                "The layout feature(s).",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
                "count-{id}",
                "The layout count(s) with the given ID.",
                "M"),
            new DataPinDefinition(DataPinValueType.Decimal,
                "dimension-{tag}",
                "The layout dimension(s) with the given tag.",
                "M")
        ]);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[PrintLayout]");

        if (!string.IsNullOrEmpty(Formula))
            sb.Append(Formula);
        if (Features?.Count > 0)
        {
            sb.Append(": ").Append(string.Join(", ", Features));
        }

        return sb.ToString();
    }
}
