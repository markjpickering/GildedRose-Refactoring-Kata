using GildedRose.Domain;
using Xunit.Abstractions;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.SulfurasTests;

public class UpdateQualityTests : TestBed<InventoryTestFixture>
{
    public IInventoryService _sut;

    public UpdateQualityTests(ITestOutputHelper testOutputHelper, InventoryTestFixture fixture)
        : base(testOutputHelper, fixture)
    {
        var sut = _fixture.GetScopedService<IInventoryService>(_testOutputHelper);
        ArgumentNullException.ThrowIfNull(sut, nameof(sut));
        _sut = sut;
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
