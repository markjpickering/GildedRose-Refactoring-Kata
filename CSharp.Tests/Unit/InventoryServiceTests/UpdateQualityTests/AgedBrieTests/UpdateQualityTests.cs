﻿using GildedRose.Domain;
using Xunit.Abstractions;

namespace CSharp.Tests.Unit.InventoryServiceTests.UpdateQualityTests.AgedBrieTests;

[CollectionDefinition("Dependency Injection")]
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
    public void WhenBeforeSellByDate_IncrementQualityBy1()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.AgedBrie, SellIn = 3, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.First().Quality.Should().Be(11);
    }

    [Fact]
    public void WhenAfterSellByDate_IncrementQualityBy2()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 10 }
            });

        // Act
        _sut.UpdateQuality(inventory);

        // Assert
        inventory.Items.First().Quality.Should().Be(12);
    }

    [Fact]
    public void WhenQuality50OrGreater_QualityMustBe50()
    {
        // Arrange
        var inventory = new Inventory(
            new List<Item>
            {
                new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 49 },
                new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 50 },
                new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 51 },

                new Item { Name = ItemNames.AgedBrie, SellIn = 1, Quality = 49 },
                new Item { Name = ItemNames.AgedBrie, SellIn = 1, Quality = 50 },
                new Item { Name = ItemNames.AgedBrie, SellIn = 1, Quality = 51 }
            });

        // Act
        _sut.UpdateQuality(inventory);
        inventory.Items.All(item => item.Quality == 50);
    }
}
