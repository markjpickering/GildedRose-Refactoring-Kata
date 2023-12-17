using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Facades.Items;

public class AgedBrieItemFacade : ItemFacadeBase, IItemFacade
{
    public AgedBrieItemFacade(Item item)
        : base(item)
    {
    }

    public void UpdateQuality()
    {
        if (Item.Quality < 50)
        {
            Item.Quality++;
        }

        if (Item.SellIn < 0)
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;
            }
        }
    }
}