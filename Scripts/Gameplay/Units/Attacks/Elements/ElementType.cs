using System.Collections.Generic;
using Godot;

public class ElementType
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public Damage damages { get; set; }
    public int MaxStacks { get; set; }
    public string Ruleset { get; set; }


}