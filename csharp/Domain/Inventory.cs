using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GildedRose.Domain;

public class Inventory
{
    public Inventory(IReadOnlyList<Item> items)
    {
        Items = new List<Item>(items);
    }

    public IList<Item> Items { get; } = new ObservableCollection<Item>();
}
