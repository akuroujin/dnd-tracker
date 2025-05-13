using System;

public class Buff : IEffect
{
    public Buff(BuffTypes type, int duration, bool isDebuff, int amount, Unit appliedTo)
    {
        Type = type;
        Duration = duration;
        this.isDebuff = isDebuff;
        Amount = amount;
        this.appliedTo = appliedTo;
    }

    public BuffTypes Type { get; init; }
    public int Duration { get; init; }
    public bool isDebuff { get; init; }
    public int Amount { get; init; }
    public Unit appliedTo { get; init; }

    public void ApplyEffect()
    {
    }


    public IEffect Finish()
    {
        throw new NotImplementedException();
    }

    public int GetDurationLeft()
    {
        throw new NotImplementedException();
    }

    public void Tick()
    {
        throw new NotImplementedException();
    }
}
