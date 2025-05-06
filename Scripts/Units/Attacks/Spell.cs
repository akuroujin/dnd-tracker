using System.Collections.Generic;

public class Spell : Attack
{
    public Spell(string name, int damageAmount, DiceType damage, int damageBonus, int range, int radius = 0, bool isBonusAction = false, bool isReaction = false) : base(name, damageAmount, damage, damageBonus, range, radius, isBonusAction, isReaction)
    {
    }

    public int Level { get; set; }
    public int CastTime { get; set; }
    public int Duration { get; set; }
    public List<Element> Elements { get; set; }
    public int Amount { get; set; }
    public int UbiCost { get; set; }


}