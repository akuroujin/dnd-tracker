public class Attack
{
    string Name { get; set; }
    int DamageAmount { get; set; }
    DiceType Damage { get; set; }
    int DamageBonus { get; set; }
    int Range { get; set; }
    int Radius { get; set; }
    bool isBonusAction { get; set; }
    bool isReaction { get; set; }
    public StatType statType { get; set; }

    public Attack(string name, int damageAmount, DiceType damage, int damageBonus, int range, int radius = 0, bool isBonusAction = false, bool isReaction = false)
    {
        Name = name;
        DamageAmount = damageAmount;
        Damage = damage;
        DamageBonus = damageBonus;
        Range = range;
        Radius = radius;
        this.isBonusAction = isBonusAction;
        this.isReaction = isReaction;
    }
    public int GetDamage()
    {
        int amount = 0;
        for (int i = 0; i < DamageAmount; i++)
        {
            amount += Dice.Roll(Damage);
        }
        return amount + DamageBonus;
    }

}