using GildedRose.Domain;
using GildedRose.Interfaces;
using GildedRose.Services;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.BackStagePasses;

public class UpdateQualityTests
{
    public IInventoryService _sut;

    public UpdateQualityTests()
    {
        _sut = new InventoryService();
    }


    [Fact]
    public void SellInMoreThan10_IncreaseQualityBy1()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 11, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 12, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 13, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.All(item => item.Quality == 11);
    }

    [Fact]
    public void SellInBetween6and10_IncreaseQualityBy2()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 6, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 7, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 8, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 9, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 10, Quality = 10 }

            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.All(item => item.Quality == 12);
    }

    [Fact]
    public void SellInBetween1and5_IncreaseQualityBy3()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 1, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 2, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 3, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 4, Quality = 10 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 5, Quality = 10 },
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.All(item => item.Quality == 13);
    }


    [Fact]
    public void WhenAfterSellByDate_QualityIs0()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 0, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.First().Quality.Should().Be(0);
    }

    [Fact]
    public void WhenQuality50OrGreater_QualityMustBe50()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 0, Quality = 49 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 0, Quality = 50 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 0, Quality = 51 },

                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 1, Quality = 49 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 1, Quality = 50 },
                new Item { Name = ItemNames.TAFKAL80ETBackstage, SellIn = 1, Quality = 51 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.All(item => item.Quality == 50);
    }
}
