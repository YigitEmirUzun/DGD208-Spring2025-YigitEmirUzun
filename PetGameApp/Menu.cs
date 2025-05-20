using System;

public static class Menu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("\n--- MAIN MENU ---");
        Console.WriteLine("1 - Steal Pets");
        Console.WriteLine("2 - View Stolen Pets");
        Console.WriteLine("3 - Feed a Pet");
        Console.WriteLine("4 - Exit");
        Console.WriteLine("5 - Credits");
        Console.Write("Choose an option: ");
    }

    public static string GetUserChoice()
    {
        return Console.ReadLine();
    }
}
