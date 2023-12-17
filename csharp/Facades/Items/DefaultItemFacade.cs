﻿using GildedRose.Domain;
namespace GildedRose.Facades.Items;

public class DefaultItemFacade : ItemFacadeBase, IItemFacade
{
    public DefaultItemFacade(Item item)
    : base(item)
    {
    }

    public void UpdateQuality()
    {
        Item.SellIn--;

        if (Item.IsQualityInRange())
        {
            if (Item.SellIn > 0)
                Item.Quality--;
            else
                Item.Quality -= 2;
        }

        Item.Quality = Item.CorrectedQuality();

    }
}
