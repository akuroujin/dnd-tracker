using Godot;
using System;
using System.Collections.Generic;

public class Monster : Unit
{
    public int ChallengeRating { get; set; }
    public HashSet<ProficiencyType> Proficiencies { get; set; }
    private int ProficiencyBonus => 2 + (ChallengeRating - 1) / 4;

    public override int GetProficiencyRoll(ProficiencyType proficiencyType)
    {
        int roll = GetStatRoll((BaseStatType)proficiencyType);
        if (!Proficiencies.Contains(proficiencyType))
            return roll;
        return roll + ProficiencyBonus;
    }
}
