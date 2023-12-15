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
        throw new System.NotImplementedException();
    }
}
