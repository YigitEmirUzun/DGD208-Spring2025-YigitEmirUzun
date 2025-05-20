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
}
