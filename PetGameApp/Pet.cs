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

    public void Feed(Item item)
    {
        int nutrition = item.NutritionValue;
        int happinessChange = item.LikesPet(Name) ? item.HappinessBoost : -item.HappinessPenalty;

        if(item.Type == ItemType.Food)
        {
            Stats.Feed(nutrition);
            Stats.Play(happinessChange);
        }
        else if(item.Type == ItemType.Toy)
        {       
            Stats.Play(happinessChange);
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
