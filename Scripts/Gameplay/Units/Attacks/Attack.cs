using System.Collections.Generic;

public class Attack
{
    string Name { get; set; }
    string Description { get; set; }

    public List<Damage> damages { get; set; }
    int Range { get; set; }
    int Radius { get; set; }
    bool isBonusAction { get; set; }
    bool isReaction { get; set; }
    public StatType statType { get; set; }

    public Attack(string name, string description, List<Damage> damage, int range, int radius = 0, bool isBonusAction = false, bool isReaction = false)
    {
        Name = name;
        Description = description;
        damages = new List<Damage>();
        Range = range;
        Radius = radius;
        this.isBonusAction = isBonusAction;
        this.isReaction = isReaction;
    }
    public virtual int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in damages)
        {
            amount += roll.GetDamage();
        }
        return amount;
    }
}