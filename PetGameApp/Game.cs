using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Game
{
    private bool _isRunning;
    private List<Pet> StolenPets = new List<Pet>();
    private const int maxPets = 3;
    private ItemDatabase itemDatabase = new ItemDatabase();

    private StealPetManager stealPetManager;
    private FeedPetManager feedPetManager;

    public Game()
    {
        stealPetManager = new StealPetManager(StolenPets, maxPets);
        feedPetManager = new FeedPetManager(StolenPets, itemDatabase);
    }

    public async Task GameLoop()
    {
        Initialize();

        _isRunning = true;
        while (_isRunning)
        {
            UpdatePetStats();

            Menu.ShowMainMenu();
            string choice = Menu.GetUserChoice();

            await ProcessUserChoice(choice);
        }

        Console.WriteLine("Thanks for playing!");
    }

    private void Initialize()
    {
        Console.WriteLine("Welcome to Pet Steal!");
    }

    private async Task ProcessUserChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                stealPetManager.StealPet();
                break;
            case "2":
                ShowStolenPets();
                break;
            case "3":
                feedPetManager.FeedPet();
                break;
            case "4":
                PlayWithPet();
                break;
            case "5":
                PutPetToSleep();
                break;
            case "6":
                ShowCredits();
                break;
            case "7":
                _isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }

        await Task.CompletedTask;
    }

    private void ShowStolenPets()
    {
        if (StolenPets.Count == 0)
        {
            Console.WriteLine("No stolen pets found.");
            return;
        }

        Console.WriteLine("Your stolen pets:");

        int count = 1;
        foreach (var pet in StolenPets)
        {
            Console.WriteLine($"{count}. {pet.Name}");
            pet.ShowAsciiArt();
            pet.ShowStats();
            count++;
        }
    }

    private void ShowCredits()
    {
        Console.WriteLine("\n--- CREDITS ---");
        Console.WriteLine("Game Developer: Yiğit Emir Uzun");
        Console.WriteLine("School Number: 225040083");
        Console.WriteLine("----------------\n");
    }

    private void UpdatePetStats()
    {
        for (int i = StolenPets.Count - 1; i >= 0; i--)
        {
            var pet = StolenPets[i];
            pet.DecreaseStatsOverTime();

            if (pet.IsDead())
            {
                Console.WriteLine($"{pet.Name} has died from hunger!");
                StolenPets.RemoveAt(i);
            }
        }
    }

    private void PlayWithPet()
    {
        if (StolenPets.Count == 0)
        {
            Console.WriteLine("You have no pets to play with.");
            return;
        }

        Console.WriteLine("Which pet do you want to play with?");
        for (int i = 0; i < StolenPets.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {StolenPets[i].Name}");
        }

        string petInput = Console.ReadLine();
        if (!int.TryParse(petInput, out int petChoice) || petChoice < 1 || petChoice > StolenPets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            return;
        }

        Pet selectedPet = StolenPets[petChoice - 1];

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

        selectedPet.Play(selectedToy.HappinessBoost);

        Console.WriteLine($"{selectedPet.Name} is playing with {selectedToy.Name} and feels happier!");
    }

    private void PutPetToSleep()
    {
        if (StolenPets.Count == 0)
        {
            Console.WriteLine("You have no pets to put to sleep.");
            return;
        }

        Console.WriteLine("Which pet do you want to put to sleep?");
        for (int i = 0; i < StolenPets.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {StolenPets[i].Name}");
        }

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int choice) || choice < 1 || choice > StolenPets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            return;
        }

        var selectedPet = StolenPets[choice - 1];
        selectedPet.SleepWell(20); 

        Console.WriteLine($"{selectedPet.Name} is now rested!");
    }
}
