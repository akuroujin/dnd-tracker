public class Resistance
{
    public ResistanceType Type;
    public bool IsImmunity;
    public int Value;

    public Resistance(ResistanceType type, bool isImmunity, int value)
    {
        Type = type;
        IsImmunity = isImmunity;
        Value = value;
    }
    public int GetResistanceDamage(int damage, ResistanceType type)
    {
        if (type != Type)
            return damage;

        if (IsImmunity)
            return 0;

        return Value / 2;
    }
}