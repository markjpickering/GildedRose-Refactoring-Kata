using GildedRose.Domain;

namespace GildedRose.Interfaces;

public interface IItemFacade
{
    public void UpdateQuality();

    public Item Item { get; }
}
