using csharp;

namespace CSharp.Tests.Unit.GuildedRose;

public class UpdateQualityTests
{
    [Fact]
    public void WhenBeforeSellByDate_DecrementQualityBy1()
    {
        // Arrange
        var Items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();

        Items.First().Quality.Should().Be(9);
    }

    [Fact]
    public void WhenAfterSellByDate_DecrementQualityBy2()
    {
        // Arrange
        var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 8 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();

        Items.First().Quality.Should().Be(8);
    }
}
