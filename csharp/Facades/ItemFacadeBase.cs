using GildedRose.Domain;

namespace GildedRose.Facades;

public abstract class ItemFacadeBase
{
    public ItemFacadeBase(Item item)
    {
        Item = item;
    }

    public Item Item { get; private set; }
}
