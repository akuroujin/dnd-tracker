using System;
using System.Collections.Generic;


public class Element : IEffect
{
    public ElementType Type { get; set; }
    public int CurrentStacks { get; set; }
    public int DurationLeft { get; set; }
    public Unit AppliedTo { get; set; }

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
