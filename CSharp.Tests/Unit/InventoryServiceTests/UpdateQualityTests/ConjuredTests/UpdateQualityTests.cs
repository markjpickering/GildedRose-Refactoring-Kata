using GildedRose.Domain;
using GildedRose.Interfaces;
using GildedRose.Services;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.ConjuredTests;

public class UpdateQualityTests
{
    /*
    public IInventoryService _sut;

    public UpdateQualityTests()
    {
        _sut = new InventoryService();
    }


    [Fact]
    public void WhenBeforeSellByDate_DecrementQualityBy1()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.C, SellIn = 3, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.First().Quality.Should().Be(9);
    }

    [Fact]
    public void WhenAfterSellByDate_DecrementQualityBy2()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = SomeRandomName, SellIn = 0, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.First().Quality.Should().Be(8);
    }

    [Fact]
    public void WhenQuality50OrGreater_QualityMustBe50()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = SomeRandomName, SellIn = 0, Quality = -1 },
                new Item { Name = SomeRandomName, SellIn = 0, Quality = 0 },
                new Item { Name = SomeRandomName, SellIn = 0, Quality = 1 },

                new Item { Name = SomeRandomName, SellIn = 1, Quality = -1 },
                new Item { Name = SomeRandomName, SellIn = 1, Quality = 0 },
                new Item { Name = SomeRandomName, SellIn = 1, Quality = 1 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.All(item => item.Quality == 0);
    }
    */
}
