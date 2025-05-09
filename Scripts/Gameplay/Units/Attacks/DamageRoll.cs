public class DamageRoll
{
    public int DiceAmount { get; set; }
    public DiceType Damage { get; set; }
    public int DamageBonus { get; set; }
    public Resistance damageType { get; set; }

    public DamageRoll(int diceAmount, DiceType damage, int damageBonus, Resistance damageType)
    {
        DiceAmount = diceAmount;
        Damage = damage;
        DamageBonus = damageBonus;
        this.damageType = damageType;
    }

    public int GetDamage()
    {
        int amount = 0;
        for (int i = 0; i < DiceAmount; i++)
        {
            amount += Dice.Roll(Damage);
        }
        return amount + DamageBonus;
    }
}