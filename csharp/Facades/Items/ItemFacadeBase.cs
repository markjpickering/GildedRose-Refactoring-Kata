using GildedRose.Domain;

namespace GildedRose.Facades.Items;

public abstract class ItemFacadeBase
{
    public ItemFacadeBase(Item item)
    {
        Item = item;
    }

    protected void EnsureQualityWithinBounds()
    {
        if(Item.Quality < 0)
            Item.Quality = 0;

        if(Item.Quality > 50)
            Item.Quality = 50;
    }

    public Item Item { get; private set; }
}
