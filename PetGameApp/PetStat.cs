public class PetStat
{
    public int Hunger { get; private set; }
    public int Fun { get; private set; }
    public int Sleep { get; private set; }

    public PetStat()
    {
        Hunger = 50;
        Fun = 50;
        Sleep = 50;
    }

    public void Feed(int amount)
    {
        Hunger += amount;
        if (Hunger > 100) Hunger = 100;
        if (Hunger < 0) Hunger = 0;
    }

    public void Play(int amount)
    {
        Fun += amount;
        if (Fun > 100) Fun = 100;
        if (Fun < 0) Fun = 0;
    }

    public void SleepWell(int amount)
    {
        Sleep += amount;
        if (Sleep > 100) Sleep = 100;
        if (Sleep < 0) Sleep = 0;
    }

    public void DecreaseOverTime()
    {
        Feed(-5);  
        Play(-3);   
        SleepWell(-2); 
    }

    public void ShowStats()
    {
        Console.WriteLine($"Hunger: {Hunger}");
        Console.WriteLine($"Fun: {Fun}");
        Console.WriteLine($"Sleep: {Sleep}");
    }
}
