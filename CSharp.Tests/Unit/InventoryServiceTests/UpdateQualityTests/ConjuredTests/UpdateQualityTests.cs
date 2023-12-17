using GildedRose;
using GildedRose.Domain;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.ConjuredTests;


public class UpdateQualityTests : Testbase
{
    public IInventoryService _sut;

    public UpdateQualityTests()
    {
        var sut = ServiceProvider.GetRequiredService<IInventoryService>();
        _sut = sut;
    }

    public override IServiceCollection CreateServices(IServiceCollection services) =>
        AppDI.AddServices(services);


    [Fact]
    public void WhenBeforeSellByDate_DecrementQualityBy2()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.ConjuredItem, SellIn = 3, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.First().Quality.Should().Be(8);
    }

    [Fact]
    public void WhenAfterSellByDate_DecrementQualityBy4()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.ConjuredItem, SellIn = -1, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.First().Quality.Should().Be(6);
    }

    [Fact]
    public void WhenQuality50OrGreater_QualityMustBe50()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = $"{ItemNames.ConjuredItem} 1", SellIn = -1, Quality = 53 },
                new Item { Name = $"{ItemNames.ConjuredItem} 2", SellIn = -1, Quality = 54 },
                new Item { Name = $"{ItemNames.ConjuredItem} 3", SellIn = -1, Quality = 55 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.Should().OnlyContain(item => item.Quality == 50);
    }

    [Fact]
    public void Sellin_MustBeDecremented()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = $"{ItemNames.ConjuredItem} 1", SellIn = 0, Quality = 49 },
                new Item { Name = $"{ItemNames.ConjuredItem} 2", SellIn = 1, Quality = 50 },
                new Item { Name = $"{ItemNames.ConjuredItem} 3", SellIn = 2, Quality = 51 },

                new Item { Name = $"{ItemNames.ConjuredItem} 4", SellIn = 3, Quality = 49 },
                new Item { Name = $"{ItemNames.ConjuredItem} 5", SellIn = 4, Quality = 50 },
                new Item { Name = $"{ItemNames.ConjuredItem} 6", SellIn = 5, Quality = 51 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items[0].SellIn.Should().Be(-1);
        inventory.Items[1].SellIn.Should().Be(0);
        inventory.Items[2].SellIn.Should().Be(1);
        inventory.Items[3].SellIn.Should().Be(2);
        inventory.Items[4].SellIn.Should().Be(3);
        inventory.Items[5].SellIn.Should().Be(4);
    }
}

