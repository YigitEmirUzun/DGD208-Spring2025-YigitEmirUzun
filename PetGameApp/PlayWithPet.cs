using System;
using System.Collections.Generic;
using System.Linq;

public static class PlayWithPetHandler
{
    public static void PlayWithPet(List<Pet> pets, ItemDatabase itemDatabase)
    {
        if (pets.Count == 0)
        {
            Console.WriteLine("You have no pets to play with.");
            return;
        }

        Console.WriteLine("Which pet do you want to play with?");
        for (int i = 0; i < pets.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {pets[i].Name}");
        }

        string petInput = Console.ReadLine();
        if (!int.TryParse(petInput, out int petChoice) || petChoice < 1 || petChoice > pets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            return;
        }

        Pet selectedPet = pets[petChoice - 1];

        var toys = itemDatabase.Items.Where(item => item.Type == ItemType.Toy).ToList();

        if (toys.Count == 0)
        {
            Console.WriteLine("No toys available to play with.");
            return;
        }

        Console.WriteLine("Available toys:");
        for (int i = 0; i < toys.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {toys[i].Name}");
        }

        string toyInput = Console.ReadLine();
        if (!int.TryParse(toyInput, out int toyChoice) || toyChoice < 1 || toyChoice > toys.Count)
        {
            Console.WriteLine("Invalid toy selection.");
            return;
        }

        Item selectedToy = toys[toyChoice - 1];

        int happinessChange = selectedToy.LikesPet(selectedPet.Name) ? selectedToy.HappinessBoost : -selectedToy.HappinessPenalty;
        selectedPet.Play(happinessChange);

        if (happinessChange > 0)
            Console.WriteLine($"{selectedPet.Name} is playing with {selectedToy.Name} and feels happier!");
        else
            Console.WriteLine($"{selectedPet.Name} didn't like playing with {selectedToy.Name} and is less happy now.");
    }
}
