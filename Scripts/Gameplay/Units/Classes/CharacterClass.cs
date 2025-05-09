using System.Collections.Generic;

public class CharacterClass
{
    public string Name { get; set; }
    public int Level { get; set; }
    public HashSet<ProficiencyType> Proficiencies { get; set; }
    public HashSet<ProficiencyType> Expertise { get; set; }
}