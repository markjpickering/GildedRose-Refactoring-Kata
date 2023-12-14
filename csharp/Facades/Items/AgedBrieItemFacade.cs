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
        Item.SellIn--;

        if (Item.IsQualityInRange())
        {
            if (Item.SellIn < 0)
                Item.Quality = Item.IncrQuality(2);
            else
                Item.Quality = Item.IncrQuality();
        }

        Item.Quality = Item.CorrectedQuality();
    }
}