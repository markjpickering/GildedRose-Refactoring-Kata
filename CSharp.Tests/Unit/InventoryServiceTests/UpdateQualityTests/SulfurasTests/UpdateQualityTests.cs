using GildedRose.Domain;
using GildedRose.Interfaces;
using GildedRose.Services;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.SulfurasTests;

public class UpdateQualityTests
{

    public IInventoryService _sut;

    public UpdateQualityTests()
    {
        _sut = new InventoryService();
    }


    [Fact]
    public void DontChangeValidQuality()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 10 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 50 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items[0].Quality.Should().Be(10);
        inventory.Items[1].Quality.Should().Be(50);
    }

    [Fact]
    public void QualityMustNeverBeGreaterThan50()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 50 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 51 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 52 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.All(item => item.Quality == 50);
    }
}
