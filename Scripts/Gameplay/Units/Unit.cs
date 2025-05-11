using Godot;
using System;
using System.Collections.Generic;

public abstract class Unit : ITurnPhases, IExportable
{
    #region Properties
    public string Name { get; set; }
    private string _name;

    public Texture2D Icon { get; set; }

    private List<DamageType> Resistances;

    private List<Attack> _attacks;
    private Attack _currentAttack = null;

    private List<Spell> _spells;

    private List<Item> Inventory;
    private List<IEquippable> equipment;

    private int[] _baseStats = new int[Enum.GetNames(typeof(BaseStatTypes)).Length];

    public int this[BaseStatTypes stat]
    {
        get => _baseStats[(int)stat];
        protected set => _baseStats[(int)stat] = value;
    }

    private int[] _stats = new int[Enum.GetNames(typeof(StatTypes)).Length];
    public int this[StatTypes stat]
    {
        get => _stats[(int)stat];
        protected set => _stats[(int)stat] = value;
    }

    bool didAction;
    bool didBonusAction;

    #endregion

    #region Combat

    // Elements on this unit
    public List<Element> takenElements = new List<Element>();

    // Effect given to other units
    public List<IEffect> givenEffects = new List<IEffect>();
    public Position Position { get; set; }


    #endregion

    #region Methods
    public abstract int GetProficiencyRoll(ProficiencyType proficiencyType);

    public int GetPassiveProficiency(ProficiencyType proficiencyType)
    {
        return 10 + (this[(BaseStatTypes)proficiencyType] - 10) / 2;
    }
    public int GetStatRoll(BaseStatTypes stat)
    {
        return Dice.Roll(DiceType.D20) + (this[stat] - 10) / 2;
    }
    public virtual int GetSaveRoll(BaseStatTypes stat)
    {
        return Dice.Roll(DiceType.D20) + this[stat] - 10;
    }
    private void Heal(int heal)
    {
        this[StatTypes.CurrentHealth] += heal;
        if (this[StatTypes.CurrentHealth] > this[StatTypes.MaxHealth])
            this[StatTypes.CurrentHealth] = this[StatTypes.MaxHealth];
    }

    protected virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Heal(damage);
            return;
        }
        if (damage > _stats[(int)StatTypes.CurrentHealth])
        {
            Die();
            return;
        }
        if (this[StatTypes.TempHealth] > 0)
        {
            this[StatTypes.TempHealth] -= damage;
            damage = -this[StatTypes.TempHealth];
            if (this[StatTypes.TempHealth] >= 0)
                return;
        }
        this[StatTypes.CurrentHealth] -= damage;
    }

    public void TakeOtherDamage(int damage, string reason)
    {
        TakeDamage(damage);
        //TODO Log reason
    }

    public void TakeAttack(Attack attack, bool isCritical = false)
    {
        TakeDamage(attack.GetDamage());
        if (isCritical)
            TakeDamage(attack.GetDamage());
    }

    public void TakeAttack(Spell spell, bool isCritical = false)
    {
        TakeAttack(spell as Attack, isCritical);
        foreach (Element element in spell.Elements)
        {
            takenElements.Add(element);
        }
    }

    public void AttackEnemy(Unit enemy, Attack attack)
    {
        int roll = Dice.Roll(DiceType.D20);
        int statroll = roll + GetStatRoll(attack.statType);
        if (statroll < enemy[StatTypes.Armorclass])
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
        //TODO: Apply effects
        foreach (IEffect effect in givenEffects)
        {
            effect.Tick();
        }
        didAction = false;
        didBonusAction = false;
    }

    public void EndTurn()
    {
        foreach (IEffect effect in givenEffects)
        {
            if (effect.GetDurationLeft() == 0)
            {
                effect.Finish();
                givenEffects.Remove(effect);
            }
        }
        //TODO: Remove elements with 0 duration
    }



    public abstract void Export(string filePath, List<IExportable> exportables = null);

    public abstract IExportable Import(string filePath);

    public abstract string ToXML();

    #endregion
}
