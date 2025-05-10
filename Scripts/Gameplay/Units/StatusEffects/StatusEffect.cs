public abstract class StatusEffect
{
    public string Name { get; set; }
    public int Duration { get; set; }
    public bool IsPermanent { get; set; }
    public Unit AffectedUnit { get; set; }

    public StatusEffect(string name, int duration, bool isPermanent, Unit affectedUnit)
    {
        Name = name;
        Duration = duration;
        IsPermanent = isPermanent;
        AffectedUnit = affectedUnit;
    }
    public abstract void Apply();
}