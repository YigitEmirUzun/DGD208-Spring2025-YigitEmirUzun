using System.Collections.Generic;

public class ItemDatabase
{
    public List<Item> Items { get; private set; }

    public ItemDatabase()
    {
        Items = new List<Item>
        {
            new Item("Worm", 20, 10, 5, new List<string> { "Frog" }),
            new Item("Bone", 30, 15, 10, new List<string> { "Dog" }),
            new Item("Seed", 10, 8, 3, new List<string> { "Bird" }),
            new Item("Banana", 25, 12, 6, new List<string> { "Monkey" }),
            new Item("Blood", 20, 10, 7, new List<string> { "Bat" })
        };
    }
}
