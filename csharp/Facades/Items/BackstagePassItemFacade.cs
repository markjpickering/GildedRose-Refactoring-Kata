using GildedRose.Domain;

namespace GildedRose.Facades.Items;

public class BackstagePassItemFacade : ItemFacadeBase, IItemFacade
{
    public BackstagePassItemFacade(Item item)
        : base(item)
    {
    }


    public void UpdateQuality()
    {
        if (Item.IsQualityInRange())
        {
            Item.Quality = Item.IncrQuality();

            if (Item.SellIn < 11)
            {
                Item.Quality = Item.IncrQuality();
            }

            if (Item.SellIn < 6)
            {
                Item.Quality = Item.IncrQuality();
            }
        }

        Item.SellIn--;

        if (Item.SellIn < 0)
            Item.Quality = 0;

        Item.Quality = Item.CorrectedQuality();
    }
}
