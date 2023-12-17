using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Facades.Items;

public class DefaultItemFacade : ItemFacadeBase, IItemFacade
{
    public DefaultItemFacade(Item item)
    : base(item)
    {
    }

    public void UpdateQuality()
    {
        if (Item.SellIn > 0)
            Item.Quality--;
        else
            Item.Quality -= 2;

        EnsureQualityWithinBounds();
    }
}
