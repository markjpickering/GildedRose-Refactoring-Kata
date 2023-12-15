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
        throw new System.NotImplementedException();
    }
}
