using System.Collections.Generic;
using System.Xml.Serialization;

public class Spell : Attack
{
    public Spell(string name, string description, List<Damage> damages, int range, int radius, bool isAction, bool isBonusAction, bool
        isReaction, BaseStatTypes statTypes, int level, int castTime, int duration, List<Element> elements, int amount, int ubiCost,
        bool isHealing, LimitType limitType, int limitAmount, int refillAmount)
    : base(name, description, damages, range, radius, isAction, isBonusAction, isReaction, statTypes)
    {
        Level = level;
        CastTime = castTime;
        Duration = duration;
        Elements = elements;
        Amount = amount;
        UbiCost = ubiCost;
        IsHealing = isHealing;
        LimitType = limitType;
        LimitAmount = limitAmount;
        RefillAmount = refillAmount;
    }

    [XmlElement]
    public int Level { get; set; }
    [XmlElement]
    public int CastTime { get; set; }
    [XmlElement]
    public int Duration { get; set; }
    [XmlElement]
    public List<Element> Elements { get; set; }
    [XmlElement]
    public int Amount { get; set; }
    [XmlElement]
    public int UbiCost { get; set; }
    [XmlElement]
    public bool IsHealing { get; set; }
    [XmlElement]
    public LimitType LimitType { get; set; }
    [XmlElement]
    public int LimitAmount { get; set; }
    [XmlElement]
    public int RefillAmount { get; set; }

    public override int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in Damages)
        {
            amount += roll.GetDamage();
        }
        return IsHealing ? amount : -amount;
    }

}
