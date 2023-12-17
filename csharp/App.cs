﻿using GildedRose.Domain;
using GildedRose.Interfaces;
using GildedRose.Services;
using System.Collections.Generic;
using System;

namespace GildedRose;

public class App : IApp
{
    private readonly IInventoryService _inventoryService;

    public App(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public void Run(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var inventory = new Inventory(new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            });


        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < inventory.Items.Count; j++)
            {
                System.Console.WriteLine(inventory.Items[j]);
            }
            Console.WriteLine("");
            _inventoryService.UpdateQuality(inventory);
        }
    }
}