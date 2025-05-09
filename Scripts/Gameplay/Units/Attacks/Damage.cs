public class Damage
{
    public int DiceAmount { get; set; }
    public DiceType diceType { get; set; }
    public int DamageBonus { get; set; }
    public Resistance damageType { get; set; }

    public Damage(int diceAmount, DiceType diceType, int damageBonus, Resistance damageType)
    {
        DiceAmount = diceAmount;
        this.diceType = diceType;
        DamageBonus = damageBonus;
        this.damageType = damageType;
    }

    public int GetDamage()
    {
        int amount = 0;
        for (int i = 0; i < DiceAmount; i++)
        {
            amount += Dice.Roll(diceType);
        }
        return amount + DamageBonus;
    }
}