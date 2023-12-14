using GildedRose.Domain;
using GildedRose.Extensions;
using GildedRose.Facades.Items;
using GildedRose.Interfaces;

namespace GildedRose.Factories;

public class ItemFacadeFactory : IItemFacadeFactory
{
    public IItemFacade CreateItemFacade(Item item)
    {
        if (item.IsAgedBrie())
            return new AgedBrieItemFacade(item);

        if(item.IsBackstagePass())
            return new BackstagePassItemFacade(item);

        if(item.IsConjured())
            return new ConjuredItemFacade(item);

        if(item.IsLegendaryItem())
            return new LegendaryItemFacade(item);

        return new DefaultItemFacade(item);
    }
}
