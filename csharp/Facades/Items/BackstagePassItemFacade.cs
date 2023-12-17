using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Facades.Items;

public class BackstagePassItemFacade : ItemFacadeBase, IItemFacade
{
    public BackstagePassItemFacade(Item item)
        : base(item)
    {
    }


    public void UpdateQuality()
    {
        if (Item.Quality < 50)
        {
            Item.Quality++;

            
            if (Item.SellIn < 11)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality++;
                }
            }

            if (Item.SellIn < 6)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality++;
                }
            }
        }
    }
}
