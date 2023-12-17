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

    private void UpdateItemQualityNew(Item item)
    {
        var itemFacade = _itemFacadeFactory.CreateItemFacade(item);
        itemFacade.UpdateQuality();
    }

    private void UpdateItemQuality(Item item)
    {
        if(item.Name == "Aged Brie")
        {
            UpdateItemQualityAgedBrie(item);
            return;
        }

        if(item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            UpdateItemQualityBackstagePasses(item);
            return;
        }

        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            UpdateItemQualitySulfuras(item);
            return;
        }

        if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            item.Quality = item.IncrQuality();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    item.Quality = item.IncrQuality();
                }

                if (item.SellIn < 6)
                {
                    item.Quality = item.IncrQuality();
                }
            }
        }
        else
        {

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality = item.DecrQuality();
            }
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn--;
        }


        if (item.SellIn < 0)
        {
            if (item.Name == "Aged Brie")
            {
                item.Quality = item.IncrQuality();

            }
            else
            {
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = 0;
                }
                else
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.DecrQuality();
                    }

                }
            }
        }

        item.Quality = item.CorrectQuality();
    }

    private void UpdateItemQualityAgedBrie(Item item) 
    {
        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality = item.IncrQuality(2);
        else
            item.Quality = item.IncrQuality();

        item.Quality = item.CorrectQuality();
    }

    private void UpdateItemQualityBackstagePasses(Item item)
    {
        item.Quality = item.IncrQuality();

        if (item.SellIn < 11)
        {
            item.Quality = item.IncrQuality();
        }

        if (item.SellIn < 6)
        {
            item.Quality = item.IncrQuality();
        }

        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality = 0;

        item.Quality = item.CorrectQuality();
    }

    private void UpdateItemQualitySulfuras(Item item)
    {
        item.SellIn -= 2;
        item.Quality = item.CorrectQuality();
    }
}
