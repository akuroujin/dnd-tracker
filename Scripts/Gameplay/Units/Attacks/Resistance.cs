public class Resistance
{
    public DamageType Type;
    public bool IsImmunity;
    public int Value;

    public Resistance(DamageType type, bool isImmunity, int value)
    {
        Type = type;
        IsImmunity = isImmunity;
        Value = value;
    }
    public int GetResistanceDamage(int damage, DamageType type)
    {
        if (type != Type)
            return damage;

        if (IsImmunity)
            return 0;

        return Value / 2;
    }
}