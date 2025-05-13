using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Monster : Unit
{


    public Monster(string name, List<DamageType> resistances, List<Attack> attacks, List<Spell> spells, List<Item> inventory, List<IEquippable> equipment, UnitBaseStats baseStats, UnitStats stats, int challengeRating, HashSet<ProficiencyType> proficiencies) : base(name, resistances, attacks, spells, inventory, equipment, baseStats, stats)
    {
        ChallengeRating = challengeRating;
        Proficiencies = proficiencies;
    }


    [XmlElement]
    public int ChallengeRating { get; set; }
    [XmlArray]
    public HashSet<ProficiencyType> Proficiencies { get; set; }


    private int ProficiencyBonus => 2 + (ChallengeRating - 1) / 4;

    public override int GetProficiencyRoll(ProficiencyType proficiencyType)
    {
        int roll = GetStatRoll((BaseStatTypes)proficiencyType);
        if (!Proficiencies.Contains(proficiencyType))
            return roll;
        return roll + ProficiencyBonus;
    }

    public override IExportable Import(string filePath)
    {
        throw new NotImplementedException();
    }

    public override string ToXML()
    {
        throw new NotImplementedException();
    }
}
