public abstract class StatusEffect : IEffect
{
    public StatusEffect(string name, int duration, bool isPermanent, Unit affectedUnit)
    {
        Name = name;
        Duration = duration;
        IsPermanent = isPermanent;
        AffectedUnit = affectedUnit;
    }

    public string Name { get; set; }
    public int Duration { get; set; }
    public bool IsPermanent { get; set; }
    public Unit AffectedUnit { get; set; }


    public void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }

    public int GetDurationLeft()
    {
        throw new System.NotImplementedException();
    }

    public IEffect Finish()
    {
        throw new System.NotImplementedException();
    }
}
