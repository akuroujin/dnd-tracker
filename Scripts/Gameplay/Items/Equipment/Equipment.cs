using System.Collections.Generic;

public class Equipment : Item
{
    public List<string> Properties { get; set; }
    public Dictionary<ProficiencyType, RollType> ProficiencyModifiers { get; set; }
}
