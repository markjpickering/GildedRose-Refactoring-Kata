using GildedRose.Domain;

namespace GildedRose.Facades.Items;

public class LegendaryItemFacade : ItemFacadeBase, IItemFacade
{
    public LegendaryItemFacade(Item item)
    : base(item)
    {
    }


    public void UpdateQuality()
    {
        Item.Quality = 80;
    }
}
