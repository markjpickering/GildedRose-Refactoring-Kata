using GildedRose.Constants;
using GildedRose.Domain;

namespace GildedRose.Extensions;

public static class ItemExtensions
{
    public static bool IsConjured(this Item thisItem) =>
        thisItem.Name.Contains("Conjured", System.StringComparison.CurrentCultureIgnoreCase);

    public static bool IsBackstagePass(this Item thisItem) =>
        thisItem.Name == ItemNames.TAFKAL80ETBackstage;

    public static bool IsLegendaryItem(this Item thisItem) =>
        thisItem.Name == ItemNames.Sulfuras;

    public static bool IsAgedBrie(this Item thisItem) =>
        thisItem.Name == ItemNames.AgedBrie;
}
