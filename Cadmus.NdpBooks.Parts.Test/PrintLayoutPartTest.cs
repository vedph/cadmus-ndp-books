using Cadmus.Core;
using Cadmus.Mat.Bricks;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.NdpBooks.Parts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadmus.NdpBooks.Parts.Test;

public sealed class PrintLayoutPartTest
{
    private static PrintLayoutPart GetPart()
    {
        PrintLayoutPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (PrintLayoutPart)seeder.GetPart(item, null, null)!;
    }

    private static PrintLayoutPart GetEmptyPart()
    {
        return new PrintLayoutPart
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        PrintLayoutPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        PrintLayoutPart part2 = TestHelper.DeserializePart<PrintLayoutPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
    }

    [Fact]
    public void GetDataPins_Empty_Zero()
    {
        PrintLayoutPart part = GetEmptyPart();

        Assert.Empty(part.GetDataPins());
    }

    [Fact]
    public void GetDataPins_NonEmpty_Ok()
    {
        PrintLayoutPart part = GetEmptyPart();
        part.SheetFormats = ["f2", "f4"];
        part.Counts =
        [
            new DecoratedCount() { Id = "sheets", Value = 2 },
        ];
        part.Features = ["drop-cap", "framed-text"];
        part.Dimensions=
        [
            new PhysicalDimension()
            {
                Tag = "margin",
                Value = 1.5f,
                Unit = "cm"
            }
        ];

        List<DataPin> pins = [.. part.GetDataPins(null)];
        Assert.Equal(6, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "sheet-format" &&
            p.Value == "f2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "sheet-format" && p.Value == "f4");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "layout-feature"
            && p.Value == "drop-cap");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "layout-feature" &&
            p.Value == "framed-text");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "count-sheets" && p.Value == "2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
