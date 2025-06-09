public class Pet
{
    public string Name { get; private set; }
    private PetStat Stats;

    public Pet(string name)
    {
        Name = name;
        Stats = new PetStat();
    }

    public void ShowStats()
    {
        Stats.ShowStats();
    }

    public bool Feed(Item item)
{
    if (item.Type != ItemType.Food)
    {
        Console.WriteLine($"{Name} can only eat food items.");
        return false;
    }

    if (item.LikesPet(Name))
    {
        Stats.Feed(item.NutritionValue);
        Stats.Play(item.HappinessBoost);
        return true;
    }
    else
    {
        Stats.Feed(-5);
        Stats.Play(-item.HappinessPenalty);
        Console.WriteLine($"{Name} did not like the {item.Name}.");
        return false;
    }
}


    public void SleepPet(int amount)
    {
        Stats.SleepWell(amount);
        Stats.Feed(-2);
        Stats.Play(-1);
    }

    public void Play(int amount)
    {
        Stats.Play(amount);
    }

    public void SleepWell(int amount)
    {
        Stats.SleepWell(amount);
    }

    public void ShowAsciiArt()
    {
        Console.WriteLine(Art.GetAsciiArt(Name));
    }

    public void DecreaseStatsOverTime()
    {
        Stats.DecreaseOverTime();
    }

    public bool IsDead()
    {
        return Stats.Hunger <= 0;
    }
}
