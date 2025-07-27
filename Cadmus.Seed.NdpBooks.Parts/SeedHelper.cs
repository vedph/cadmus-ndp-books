using Bogus;
using Cadmus.NdpBooks.Parts;
using System.Collections.Generic;

namespace Cadmus.Seed.NdpBooks.Parts;

internal static class SeedHelper
{
    public static List<FigPlanItem> GetFigPlanItems(int count)
    {
        List<FigPlanItem> items = [];
        Dictionary<string, int> types = new()
        {
            { "illustration", 0 },
            { "initial", 0 },
            { "ornament", 0 }
        };

        for (int i = 0; i < count; i++)
        {
            FigPlanItem item = new Faker<FigPlanItem>()
                .RuleFor(p => p.Type,
                    f => f.PickRandom("illustration", "initial", "ornament"))
                .RuleFor(p => p.Citation, f => f.Random.Bool(0.3f)
                    ? $"{f.Random.Number(1, 10)}.{f.Random.Number(1, 10)}"
                    : null)
                .Generate();
            types[item.Type]++;
            item.Eid = $"{item.Type}-{types[item.Type]}";
            items.Add(item);
        }

        return items;
    }
}
