using GildedRose.Domain;
using GildedRose.Interfaces;

namespace GildedRose.Services;

public class InventoryService : IInventoryService
{
    public void UpdateQuality(Inventory inventory)
    {
        for (var i = 0; i < inventory.Items.Count; i++)
        {
            if (inventory.Items[i].Name != "Aged Brie" && inventory.Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (inventory.Items[i].Quality > 0)
                {
                    if (inventory.Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        inventory.Items[i].Quality = inventory.Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (inventory.Items[i].Quality < 50)
                {
                    inventory.Items[i].Quality = inventory.Items[i].Quality + 1;

                    if (inventory.Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventory.Items[i].SellIn < 11)
                        {
                            if (inventory.Items[i].Quality < 50)
                            {
                                inventory.Items[i].Quality = inventory.Items[i].Quality + 1;
                            }
                        }

                        if (inventory.Items[i].SellIn < 6)
                        {
                            if (inventory.Items[i].Quality < 50)
                            {
                                inventory.Items[i].Quality = inventory.Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (inventory.Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                inventory.Items[i].SellIn = inventory.Items[i].SellIn - 1;
            }

            if (inventory.Items[i].SellIn < 0)
            {
                if (inventory.Items[i].Name != "Aged Brie")
                {
                    if (inventory.Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventory.Items[i].Quality > 0)
                        {
                            if (inventory.Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                inventory.Items[i].Quality = inventory.Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        inventory.Items[i].Quality = inventory.Items[i].Quality - inventory.Items[i].Quality;
                    }
                }
                else
                {
                    if (inventory.Items[i].Quality < 50)
                    {
                        inventory.Items[i].Quality = inventory.Items[i].Quality + 1;
                    }
                }
            }
        }
    }
}
