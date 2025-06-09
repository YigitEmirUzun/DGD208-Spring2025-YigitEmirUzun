using System;
using System.Collections.Generic;
using System.Linq;

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

        if (!int.TryParse(Console.ReadLine(), out int petChoice) || petChoice < 1 || petChoice > stolenPets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            return;
        }

        Pet selectedPet = stolenPets[petChoice - 1];

        var foods = itemDatabase.Items.Where(item => item.Type == ItemType.Food).ToList();

        if (foods.Count == 0)
        {
            Console.WriteLine("No food items available.");
            return;
        }

        Console.WriteLine("Which food do you want to use to feed the pet?");
        for (int i = 0; i < foods.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {foods[i].Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int foodChoice) || foodChoice < 1 || foodChoice > foods.Count)
        {
            Console.WriteLine("Invalid food selection.");
            return;
        }

        Item selectedFood = foods[foodChoice - 1];

        bool fedSuccessfully = selectedPet.Feed(selectedFood);

        if (fedSuccessfully)
            Console.WriteLine($"{selectedPet.Name} has been fed with {selectedFood.Name}.");
    }

}
