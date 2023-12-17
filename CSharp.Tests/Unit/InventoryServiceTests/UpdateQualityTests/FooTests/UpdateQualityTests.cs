using GildedRose.Domain;
using Xunit.Abstractions;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.FooTests;

public class UpdateQualityTests : TestBed<InventoryTestFixture>
{
    public const string SomeRandomName = "foo";

    public IInventoryService _sut;

    public UpdateQualityTests(ITestOutputHelper testOutputHelper, InventoryTestFixture fixture)
        : base(testOutputHelper, fixture)
    {
        var sut = _fixture.GetScopedService<IInventoryService>(_testOutputHelper);
        ArgumentNullException.ThrowIfNull(sut, nameof(sut));
        _sut = sut;    }



    [Fact]
    public void WhenBeforeSellByDate_DecrementQualityBy1()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = SomeRandomName, SellIn = 3, Quality = 10 }
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
}
