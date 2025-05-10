using Godot;
using System;
using System.Collections.Generic;

public abstract class Unit : ITurnPhases
{
    #region Properties
    public string Name { get; set; }
    public Texture2D Icon { get; set; }
    public int MaxHealth { get; set; }
    public int MaxUbi { get; set; }
    public int CurrentUbi { get; set; }
    public int WalkSpeed { get; set; }
    public Dictionary<StatType, int> Stats = new Dictionary<StatType, int>();
    public int ArmorClass { get; set; }
    public List<DamageType> Resistances { get; set; }
    public List<Attack> Attacks { get; set; }
    public List<Spell> Spells { get; set; }
    public List<Item> Inventory { get; set; }

    #endregion

    #region Combat
    public int Initiative { get; set; }
    public int CurrentHealth { get; set; }
    public int TempHealth { get; set; }
    // Elements on this unit
    public List<Element> takenElements = new List<Element>();
    // Elements given to other units
    public List<Element> givenElements = new List<Element>();
    public Position Position { get; set; }


    #endregion

    #region Methods
    public abstract int GetProficiencyRoll(ProficiencyType proficiencyType);

    public int GetPassiveProficiency(ProficiencyType proficiencyType)
    {
        return 10 + (Stats[(StatType)proficiencyType] - 10) / 2;
    }
    public int GetStatRoll(StatType statType)
    {
        return Dice.Roll(DiceType.D20) + (Stats[statType] - 10) / 2;
    }
    public virtual int GetSaveRoll(StatType statType)
    {
        return Dice.Roll(DiceType.D20) + Stats[statType] - 10;
    }
    private void Heal(int heal)
    {
        CurrentHealth += heal;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    protected virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Heal(damage);
            return;
        }
        if (damage > MaxHealth)
        {
            Die();
            return;
        }
        if (TempHealth > 0)
        {
            TempHealth -= damage;
            damage = -TempHealth;
            if (TempHealth >= 0)
                return;
        }
        CurrentHealth -= damage;
    }

    public void TakeOtherDamage(int damage, string reason)
    {
        TakeDamage(damage);
    }

    public void TakeAttack(Attack attack, bool isCritical = false)
    {
        TakeDamage(attack.GetDamage());


        if (!isCritical)
            return;
        if (attack is Spell spell)
        {
            foreach (Element element in spell.Elements)
            {
                takenElements.Add(element);
            }
        }
    }

    public void ElementTick(Element element)
    {
        if (!takenElements.Contains(element))
            return;
        if (element.DurationLeft <= 0)
            takenElements.Remove(element);
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
    protected void Die()
    {
        //TODO: change image to desaturated version
    }


    public void StartTurn()
    {

    }
    public void EndTurn()
    {

    }

    #endregion

    #region File Management
    void ExportToJSON()
    {
        //TODO: export to json
    }
    #endregion
}
