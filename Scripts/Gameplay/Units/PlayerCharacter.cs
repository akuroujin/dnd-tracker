using Godot;
using System;
using System.Collections.Generic;

public class PlayerCharacter : Unit, IExportable
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

    public int ProficiencyBonus => 2 + (Level - 1) / 4;

    #endregion
    private bool isDowned => this[StatTypes.CurrentHealth] <= 0;
    private int DeathFailCount = 0;
    private int DeathSuccessCount = 0;

    public override int GetProficiencyRoll(ProficiencyType proficiencyType)
    {
        int roll = GetStatRoll((BaseStatTypes)proficiencyType);
        int value = roll;
        if (Classes[0].Proficiencies.Contains(proficiencyType))
            value += ProficiencyBonus;
        if (Classes[0].Expertise.Contains(proficiencyType))
            value += ProficiencyBonus;
        return value;

    }
    private void DeathThrow()
    {
        int roll = Dice.Roll(DiceType.D20);
        switch (roll)
        {
            case 1:
                DeathFailCount++;
                break;
            case 20:
                Revive();
                break;
            case < 10:
                DeathFailCount++;
                break;
            case > 10:
                DeathSuccessCount++;
                break;
            default:
                break;
        }
        if (DeathFailCount >= 3)
            Die();
        if (DeathSuccessCount >= 3)
            Revive();
    }
    private void Revive()
    {
        this[StatTypes.CurrentHealth] = 1;
        DeathFailCount = 0;
        DeathSuccessCount = 0;
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (isDowned)
        {
            DeathThrow();
        }
    }
    public override int GetSaveRoll(BaseStatTypes stat)
    {
        return base.GetSaveRoll(stat);
    }
}
