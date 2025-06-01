using System;

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
        Stats.Feed(nutrition);
        Stats.Play(happinessChange);
    }

    public void ShowAsciiArt()
    {
        Console.WriteLine(Art.GetAsciiArt(Name));
    }

    public void DecreaseStatsOverTime()
    {
        Stats.Feed(-5);    
        Stats.Play(-3);      
        Stats.SleepWell(-2); 
    }

    public bool IsDead()
    {
        return Stats.Hunger <= 0;
    }
}
