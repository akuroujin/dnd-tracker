using System.Xml.Serialization;
public class Damage : IDamage
{
    public Damage(int damage, Resistance damageType)
    {
        DamageBonus = damage;
        DamageType = damageType;

    }
    public Damage(int diceAmount, DiceTypes diceType, int damageBonus, Resistance damageType)
    {
        DiceAmount = diceAmount;
        this.DiceType = diceType;
        DamageBonus = damageBonus;
        this.DamageType = damageType;
    }

    [XmlElement]
    public int DiceAmount { get; init; } = 0;
    [XmlElement]
    public DiceTypes DiceType { get; init; } = DiceTypes.FLAT;
    [XmlElement]
    public int DamageBonus { get; init; } = 0;
    [XmlElement]
    public Resistance DamageType { get; init; }



    public int GetDamage()
    {
        int amount = 0;
        for (int i = 0; i < DiceAmount; i++)
        {
            amount += Dice.Roll(DiceType);
        }
        return amount + DamageBonus;
    }
}
