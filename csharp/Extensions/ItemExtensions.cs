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

    public static bool IsConjuredItem(this Item thisItem) =>
        thisItem.Name.Contains(ItemNames.ConjuredItem, System.StringComparison.CurrentCultureIgnoreCase);

    public static bool IsAgedBrie(this Item thisItem) =>
        thisItem.Name == ItemNames.AgedBrie;

    public static int IncrQuality(this Item thisItem, int amount = 1) =>
        (thisItem.Quality + amount) switch
        {
            > 50 => 50,
            _ => thisItem.Quality + amount,
        };

    public static int DecrQuality(this Item thisItem, int amount = 1) =>
        (thisItem.Quality - amount) switch
        {
            <= 0 => 0,
            _ => thisItem.Quality - amount,
        };

    public static int CorrectedQuality(this Item thisItem) =>
        (thisItem.Quality) switch
        {
            <= 0 => 0,
            > 50 => 50,
            _ => thisItem.Quality,
        };

    public static bool IsQualityInRange(this Item thisItem) =>
        !thisItem.IsQualityOutOfRange();

    public static bool IsQualityOutOfRange(this Item thisItem) =>
        (thisItem.Quality) switch
        {
            < 0 => true,
            > 50 => true,
            _ => false
        };
}
