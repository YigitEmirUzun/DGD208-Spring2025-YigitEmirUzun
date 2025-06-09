using System.Collections.Generic;

public class ItemDatabase
{
    public List<Item> Items { get; private set; }

    public ItemDatabase()
    {
        Items = new List<Item>
        {
            new Item("Worm", 20, 10, 5, new List<string> { "Frog" }, ItemType.Food),
            new Item("Bone", 30, 15, 10, new List<string> { "Dog" }, ItemType.Food),
            new Item("Seed", 10, 8, 3, new List<string> { "Bird" }, ItemType.Food),
            new Item("Banana", 25, 12, 6, new List<string> { "Monkey" }, ItemType.Food),
            new Item("Blood", 20, 10, 7, new List<string> { "Bat" }, ItemType.Food),

            new Item("Rubber Ball", 0, 20, 0, new List<string> { "Dog", "Monkey" }, ItemType.Toy),
            new Item("Chew Toy", 0, 15, 0, new List<string> { "Dog" }, ItemType.Toy),
            new Item("Swing", 0, 18, 0, new List<string> { "Monkey" }, ItemType.Toy)
        };
    }
}


