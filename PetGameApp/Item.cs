using System.Collections.Generic;

public class Item
{
    public string Name { get; set; }
    public int NutritionValue { get; set; }     
    public int HappinessBoost { get; set; }     
    public int HappinessPenalty { get; set; }    
    public List<string> LikedByPets { get; set; }
    public ItemType Type { get; set; }       

    public Item(string name, int nutrition, int happyBoost, int happyPenalty, List<string> likedByPets, ItemType type)
    {
        Name = name;
        NutritionValue = nutrition;
        HappinessBoost = happyBoost;
        HappinessPenalty = happyPenalty;
        LikedByPets = likedByPets;
        Type = type;
    }

    public bool LikesPet(string petName)
    {
        return LikedByPets.Contains(petName);
    }
}
