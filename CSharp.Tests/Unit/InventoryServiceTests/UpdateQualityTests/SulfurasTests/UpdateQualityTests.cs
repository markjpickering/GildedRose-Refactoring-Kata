using GildedRose;
using GildedRose.Domain;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.SulfurasTests;

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
        inventory.Items.Should().OnlyContain(item => item.Quality == 50);
    }
}
