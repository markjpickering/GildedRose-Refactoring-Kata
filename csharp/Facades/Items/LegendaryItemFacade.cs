using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Facades.Items;

public class LegendaryItemFacade : ItemFacadeBase, IItemFacade
{
    public LegendaryItemFacade(Item item)
    : base(item)
    {
    }


    public void UpdateQuality()
    {        
    }
}
