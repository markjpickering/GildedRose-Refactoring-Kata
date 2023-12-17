using GildedRose.Domain;

namespace GildedRose.Services;

public class InventoryService : IInventoryService
{
    private IItemFacadeFactory _itemFacadeFactory;

    public InventoryService(IItemFacadeFactory itemFacadeFactory)
    {
        _itemFacadeFactory = itemFacadeFactory;
    }

    public void UpdateQuality(Inventory inventory)
    {
        for (var i = 0; i < inventory.Items.Count; i++)
        {
            UpdateItemQuality(inventory.Items[i]);
        }
    }

    private void UpdateItemQuality(Item item)
    {
        var itemFacade = _itemFacadeFactory.CreateItemFacade(item);
        itemFacade.UpdateQuality();
    }
}
