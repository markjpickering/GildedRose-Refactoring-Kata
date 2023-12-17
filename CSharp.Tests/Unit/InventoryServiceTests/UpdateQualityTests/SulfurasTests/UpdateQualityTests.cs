using GildedRose;
using GildedRose.Domain;

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
    public void QualityMustBe80()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 49 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 50 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 51 },

                new Item { Name = ItemNames.Sulfuras, SellIn = 1, Quality = 49 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 1, Quality = 50 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 1, Quality = 51 },

                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 0 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = -1 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = -2 },

            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.Should().OnlyContain(item => item.Quality == 80);
    }

    [Fact]
    public void Sellin_MustRemainUnchanged()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 49 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 1, Quality = 50 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 2, Quality = 51 },

                new Item { Name = ItemNames.Sulfuras, SellIn = 3, Quality = 49 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 4, Quality = 50 },
                new Item { Name = ItemNames.Sulfuras, SellIn = 5, Quality = 51 },
                new Item { Name = ItemNames.Sulfuras, SellIn = -1, Quality = 53 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items[0].SellIn.Should().Be(0);
        inventory.Items[1].SellIn.Should().Be(1);
        inventory.Items[2].SellIn.Should().Be(2);
        inventory.Items[3].SellIn.Should().Be(3);
        inventory.Items[4].SellIn.Should().Be(4);
        inventory.Items[5].SellIn.Should().Be(5);
        inventory.Items[6].SellIn.Should().Be(-1);
    }
}
