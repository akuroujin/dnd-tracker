using Godot;
using System;
using System.Collections.Generic;

public abstract class Unit
{
    #region Properties

    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int MaxUbi { get; set; }
    public int CurrentUbi { get; set; }
    public int WalkSpeed { get; set; }
    public Dictionary<StatType, int> Stats = new Dictionary<StatType, int>();
    public int ArmorClass { get; set; }
    public int Initiative { get; set; }
    public List<DamageType> Resistances { get; set; }
    public List<Attack> Attacks { get; set; }
    public List<Spell> Spells { get; set; }

    #endregion

    #region Combat
    public int CurrentHealth { get; set; }

    public List<Element> appliedElements = new List<Element>();

    #endregion

    public Unit(string name, int maxHealth, int currentHealth, int maxUbi, int currentUbi, int walkSpeed,
        int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
        int armorClass, int initiative, List<DamageType> resistances, List<Attack> attacks, List<Spell> spells)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        MaxUbi = maxUbi;
        CurrentUbi = currentUbi;
        WalkSpeed = walkSpeed;
        Stats.Add(StatType.Strength, strength);
        Stats.Add(StatType.Dexterity, dexterity);
        Stats.Add(StatType.Constitution, constitution);
        Stats.Add(StatType.Intelligence, intelligence);
        Stats.Add(StatType.Wisdom, wisdom);
        Stats.Add(StatType.Charisma, charisma);
        ArmorClass = armorClass;
        Initiative = initiative;
        Resistances = resistances;
        Attacks = attacks;
        Spells = spells;
    }

    private int GetStatRoll(StatType statType)
    {
        return (Stats[statType] - 10) / 2;
    }
    public void TakeDamage(int damage, string reason)
    {

    }

    public void TakeAttack(Attack attack, bool isCritical = false)
    {
        CurrentHealth -= attack.GetDamage();
        if (isCritical)
            return;


    }

    public void AttackEnemy(Unit enemy, Attack attack)
    {
        int roll = Dice.Roll(DiceType.D20);
        int statroll = roll + GetStatRoll(attack.statType);
        if (statroll < enemy.ArmorClass)
        {
            return;
        }
        enemy.TakeAttack(attack);
        if (roll == 20)
            enemy.TakeAttack(attack, true);
    }
}
