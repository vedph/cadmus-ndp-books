using Bogus;
using Cadmus.Core;
using Cadmus.NdpBooks.Parts;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.NdpBooks.Parts;

/// <summary>
/// Seeder for <see cref="PrintLayoutPart"/>.
/// Tag: <c>seed.it.vedph.ndp.print-layout</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.ndp.print-layout")]
public sealed class PrintLayoutPartSeeder : PartSeederBase
{
    private static List<DecoratedCount> GetDecoratedCounts()
    {
        List<DecoratedCount> counts = [];
        for (int n = 1; n < 2; n++)
        {
            counts.Add(new Faker<DecoratedCount>()
                .RuleFor(c => c.Value, f => f.Random.Int(1, 10))
                .RuleFor(c => c.Tag, f => n == 1 ? "sheets" : "columns"));
        }
        return counts;
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);

        PrintLayoutPart part = new Faker<PrintLayoutPart>()
           .RuleFor(p => p.SheetFormats, f => [f.PickRandom("f2", "f4", "f8")])
           .RuleFor(p =>p.Counts, f => GetDecoratedCounts())
           .RuleFor(p => p.Features, f => [f.PickRandom("drop-cap", "framed-text")])
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
