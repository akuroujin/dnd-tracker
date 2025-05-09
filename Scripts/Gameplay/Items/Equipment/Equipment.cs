using System.Collections.Generic;

public class Equipment : Item
{
    public List<string> Properties { get; set; }
    public Dictionary<ProficiencyType, RollType> Proficiencies { get; set; }
}
