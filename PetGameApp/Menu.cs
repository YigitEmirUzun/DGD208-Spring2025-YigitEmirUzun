public static class Menu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("\n--- MAIN MENU ---");
        Console.WriteLine("1. Steal Pet");
        Console.WriteLine("2. Show Stolen Pets");
        Console.WriteLine("3. Feed Pet");
        Console.WriteLine("4. Play With Pet");
        Console.WriteLine("5. Put Pet To Sleep");
        Console.WriteLine("6. Credits");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
    }

    public static string GetUserChoice()
    {
        return Console.ReadLine();
    }
}
