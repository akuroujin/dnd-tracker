using Godot;
using System;
using System.Collections.Generic;

public abstract class Unit : IObservable<Unit>, IObserver<Unit>
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

    #endregion

    #region Combat
    public int Initiative { get; set; }
    public int CurrentHealth { get; set; }
    public int TempHealth { get; set; }
    public List<Element> appliedElements = new List<Element>();
    public Position Position { get; set; }
    public bool IsDead => CurrentHealth <= 0;

    #endregion

    #region Methods
    public abstract int GetProficiencyRoll(ProficiencyType proficiencyType);
    public int GetStatRoll(StatType statType)
    {
        return Dice.Roll(DiceType.D20) + (Stats[statType] - 10) / 2;
    }
    public virtual int GetSaveRoll(StatType statType)
    {
        return Stats[statType] - 10;
    }

    public void TakeDamage(int damage, string reason)
    {

    }

    public void TakeAttack(Attack attack, bool isCritical = false)
    {
        CurrentHealth -= attack.GetDamage();
        if (!isCritical)
            return;
        Dice.Roll(DiceType.D20, RollType.Disadvantage);
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
    private void Die()
    {
        //TODO: change image to desaturated version
    }
    #endregion

    #region Observer
    public IDisposable Subscribe(IObserver<Unit> observer)
    {
        //TODO: add unit to observer, apply effects
        throw new NotImplementedException();
    }

    public void OnCompleted()
    {
        //TODO: final application of effects and remove
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        GD.Print(error);
        throw new NotImplementedException();
    }

    public void OnNext(Unit value)
    {
        //TODO: apply effect, remove duration
        throw new NotImplementedException();
    }
    #endregion
}
