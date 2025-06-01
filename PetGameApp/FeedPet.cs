using System;
using System.Collections.Generic;

public class FeedPetManager
{
    private List<Pet> stolenPets;
    private ItemDatabase itemDatabase;

    public FeedPetManager(List<Pet> stolenPets, ItemDatabase itemDatabase)
    {
        this.stolenPets = stolenPets;
        this.itemDatabase = itemDatabase;
    }

    public void FeedPet()
    {
        if (stolenPets.Count == 0)
        {
            Console.WriteLine("You have no pets to feed.");
            return;
        }

        Console.WriteLine("Which pet do you want to feed?");
        for (int i = 0; i < stolenPets.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {stolenPets[i].Name}");
        }

        string petChoiceInput = Console.ReadLine();
        if (!int.TryParse(petChoiceInput, out int petChoice) || petChoice < 1 || petChoice > stolenPets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            return;
        }

        Pet selectedPet = stolenPets[petChoice - 1];

        Console.WriteLine("Which item do you want to use to feed the pet?");
        for (int i = 0; i < itemDatabase.Items.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {itemDatabase.Items[i].Name}");
        }

        string itemChoiceInput = Console.ReadLine();
        if (!int.TryParse(itemChoiceInput, out int itemChoice) || itemChoice < 1 || itemChoice > itemDatabase.Items.Count)
        {
            Console.WriteLine("Invalid item selection.");
            return;
        }

        Item selectedItem = itemDatabase.Items[itemChoice - 1];

        selectedPet.Feed(selectedItem);

        Console.WriteLine($"{selectedPet.Name} has been fed with {selectedItem.Name}.");
    }
}

