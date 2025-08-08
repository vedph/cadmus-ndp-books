using System;
using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.NdpBooks.Parts;

/// <summary>
/// TODO: add summary
/// <para>Tag: <c>it.vedph.ndp.print-fig-plan-impl</c>.</para>
/// </summary>
[Tag("it.vedph.ndp.print-fig-plan-impl")]
public sealed class FigurativePlanImplPart : PartBase
{
    /// <summary>
    /// True if the implementation is complete with reference to the plan.
    /// </summary>
    public bool IsComplete { get; set; }

    /// <summary>
    /// Techniques used in the figurative plan (e.g. copper engraving, woodcut,
    /// lithograph, etching). Usually from thesaurus <c>fig-plan-techniques</c>.
    /// Overrides the techniques of the plan, if any. If no technique is
    /// specified here, all the plan's techniques are implied. If any technique
    /// is specified, this implies that these techniques fully replace the
    /// plan's techniques.
    /// </summary>
    public List<string> Techniques { get; set; } = [];

    /// <summary>
    /// The items in the figurative plan implementation.
    /// </summary>
    public List<FigPlanItemImpl>? Items { get; set; }

    /// <summary>
    /// Free text description of the figurative plan implementation.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Features about the implementation, e.g. frame, frieze, etc.
    /// Usually from thesaurus <c>fig-plan-impl-features</c>.
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
        // TODO: build pins, eventually using DataPinBuilder like this
        // (optionally using DataPinHelper.DefaultFilter as an argument):
        // DataPinBuilder builder = new(new StandardDataPinTextFilter());
        //// latitude
        // builder.AddValue("lat", Latitude);
        //// tot-count
        //builder.Set("tot", Entries?.Count ?? 0, false);
        //return builder.Build(this);

        // ...or just use a simpler logic, like:
        // sample:
        // return Tag != null
        //    ? new[]
        //    {
        //        CreateDataPin("tag", Tag)
        //    }
        //    : Enumerable.Empty<DataPin>();

        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(
        [
            // TODO: add pins definitions...
            // sample:
            // new DataPinDefinition(DataPinValueType.Integer,
            //    "tot-count",
            //    "The total count of entries.")
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

        sb.Append("[__NAME__]");

        // TODO: append summary data...

        return sb.ToString();
    }
}
