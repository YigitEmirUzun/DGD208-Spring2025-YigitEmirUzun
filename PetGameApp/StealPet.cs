using System;
using System.Collections.Generic;

public class StealPetManager
{
    private readonly int maxPets;
    private readonly List<Pet> stolenPets;

    public StealPetManager(List<Pet> stolenPets, int maxPets)
    {
        this.stolenPets = stolenPets;
        this.maxPets = maxPets;
    }

    public void StealPet()
    {
        if (stolenPets.Count >= maxPets)
        {
            Console.WriteLine($"You have reached the maximum number of pets you can steal ({maxPets}).");
            return;
        }

        string[] petNames = { "Frog", "Dog", "Bird", "Monkey", "Bat" };

        Console.WriteLine("Choose a pet to steal:");
        for (int i = 0; i < petNames.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {petNames[i]}");
        }

        Console.Write("Enter the number of the pet you want to steal: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int petIndex) && petIndex >= 1 && petIndex <= petNames.Length)
        {
            string selectedPetName = petNames[petIndex - 1];
            Pet newPet = new Pet(selectedPetName);
            stolenPets.Add(newPet);
            Console.WriteLine($"You stealed a {selectedPetName}!");
        }
        else
        {
            Console.WriteLine("Invalid pet selection.");
        }
    }
}
