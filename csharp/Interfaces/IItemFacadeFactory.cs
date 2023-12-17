using GildedRose.Domain;

namespace GildedRose.Interfaces;

public interface IItemFacadeFactory
{
    IItemFacade CreateItemFacade(Item item);
}
