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
        throw new System.NotImplementedException();
    }
}
