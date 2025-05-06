using System.Collections.Generic;

public class Spell : Attack
{
    public Spell(string name, string description, int level, int castTime, int duration, List<Element> elements, int amount, int ubiCost) : base(name, description, new List<DamageRoll>(), 0, 0)
    {
        Level = level;
        CastTime = castTime;
        Duration = duration;
        Elements = elements;
        Amount = amount;
        UbiCost = ubiCost;
    }

    public int Level { get; set; }
    public int CastTime { get; set; }
    public int Duration { get; set; }
    public List<Element> Elements { get; set; }
    public int Amount { get; set; }
    public int UbiCost { get; set; }
    public bool IsHealing { get; set; }
    public LimitType LimitType { get; set; }
    public int LimitAmount { get; set; }

    public override int GetDamage()
    {
        int amount = 0;
        foreach (DamageRoll roll in Damage)
        {
            amount += roll.GetDamage();
        }
        return IsHealing ? amount : -amount;
    }

}