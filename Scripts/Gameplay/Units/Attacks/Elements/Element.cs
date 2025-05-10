using System;
using System.Collections.Generic;

public class Element : ITurnPhases
{
    public ElementType Type { get; set; }
    public int CurrentStacks { get; set; }
    public int DurationLeft { get; set; }
    public Unit AppliedTo { get; set; }

    public void EndTurn()
    {
        throw new NotImplementedException();
    }

    public void StartTurn()
    {
        throw new NotImplementedException();
    }
}