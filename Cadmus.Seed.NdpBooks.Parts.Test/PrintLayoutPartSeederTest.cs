using Cadmus.Core;
using Cadmus.NdpBooks.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.NdpBooks.Parts.Test;

public sealed class PrintLayoutPartSeederTest
{
    private static readonly PartSeederFactory _factory =
        TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions =
        _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(PrintLayoutPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.ndp.print-layout", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        PrintLayoutPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        PrintLayoutPart? p = part as PrintLayoutPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);

        Assert.NotNull(p.SheetFormats);
        Assert.NotEmpty(p.SheetFormats);

        Assert.NotNull(p.Counts);
        Assert.NotEmpty(p.Counts);

        Assert.NotNull(p.Features);
        Assert.NotEmpty(p.Features);
    }
}
