using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Facades.Items;

public class ConjuredItemFacade : ItemFacadeBase, IItemFacade
{
    public ConjuredItemFacade(Item item)
        : base(item)
    {
    }


    public void UpdateQuality()
    {
        if (Item.IsQualityInRange())
        {
            if (Item.SellIn < 0)
                Item.Quality = Item.DecrQuality(4);
            else
                Item.Quality = Item.DecrQuality(2);
        }

        Item.SellIn--;

        Item.Quality = Item.CorrectedQuality();
    }
}
