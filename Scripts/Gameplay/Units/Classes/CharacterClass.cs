using System.Collections.Generic;
using System;

public class CharacterClass
{
    public string Name { get; }
    private string _name;
    public int Level { get; set; }
    public HashSet<ProficiencyType> Proficiencies { get; set; }
    public HashSet<ProficiencyType> Expertise { get; set; }
    public CharacterClass(string name)
    {
        _name = name;
    }
}
