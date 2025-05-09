using Godot;
using System;
using System.Collections.Generic;

public class PlayerCharacter : Unit
{
    #region Properties
    public int Experience { get; set; }
    public int Level
    {
        get
        {
            int level = 0;
            foreach (CharacterClass characterClass in Classes)
            {
                level += characterClass.Level;
            }
            return level;
        }
    }

    public List<CharacterClass> Classes { get; set; }

    public List<SubClass> SubClasses { get; set; }

    private int ProficiencyBonus => 2 + (Level - 1) / 4;


    #endregion

    public override int GetProficiencyRoll(ProficiencyType proficiencyType)
    {
        int roll = GetStatRoll((StatType)proficiencyType);
        int value = roll;
        if (Classes[0].Proficiencies.Contains(proficiencyType))
            value += ProficiencyBonus;
        if (Classes[0].Expertise.Contains(proficiencyType))
            value += ProficiencyBonus;
        return value;

    }
    public override int GetSaveRoll(StatType statType)
    {
        return base.GetSaveRoll(statType);
    }
}
