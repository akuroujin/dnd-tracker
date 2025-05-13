using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public abstract class Unit : ITurnPhases, IExportable
{

    protected Unit(string name, List<Resistance> resistances, List<Attack> attacks, List<Spell> spells, List<Item> inventory, List<IEquippable> equipment, UnitBaseStats baseStats, UnitStats stats)
    {
        Name = name;
        Resistances = resistances;
        Attacks = attacks;
        Spells = spells;
        Inventory = inventory;
        this.Equipment = equipment;
        BaseStats = baseStats;
        Stats = stats;
    }

    #region Properties

    [XmlAttribute]
    public string id
    {
        get
        {
            string value = Name.ToLower();
            value = value.Trim();
            value = value.Replace(' ', '_');
            return value;
        }
    }
    [XmlElement]
    public string Name { get; private set; }

    [XmlArray]
    [XmlArrayItem("Resistance")]
    private List<Resistance> Resistances;

    [XmlArray]
    [XmlArrayItem("Attack")]
    public List<Attack> Attacks { get; private set; }


    [XmlArray]
    [XmlArrayItem("Spell")]
    public List<Spell> Spells { get; private set; }

    [XmlArray]
    [XmlArrayItem("Item")]
    public List<Item> Inventory { get; private set; }

    [XmlArray("Equipments")]
    [XmlArrayItem("Equipment")]
    public List<IEquippable> Equipment { get; private set; }


    private UnitBaseStats _baseStats;
    [XmlArray("BaseStats")]
    [XmlArrayItem("BaseStat")]
    public UnitBaseStats BaseStats
    {
        get => _baseStats;
        private set => _baseStats = value;
    }
    [XmlIgnore]
    public int this[BaseStatTypes stat]
    {
        get => _baseStats[stat];
        protected set => _baseStats[stat] = value;
    }

    private UnitStats _stats;
    [XmlArray("Stats")]
    [XmlArrayItem("Stat")]
    public UnitStats Stats
    {
        get => _stats;
        private set => _stats = value;
    }
    [XmlIgnore]
    public int this[StatTypes stat]
    {
        get => _stats[stat];
        protected set => _stats[stat] = value;
    }

    bool _didAction = false;
    bool _didBonusAction = false;
    Spell _currentAttack = null;

    #endregion

    #region Combat

    // Elements on this unit
    [XmlIgnore]
    public List<Element> takenElements = new List<Element>();

    // Effect given to other units
    [XmlIgnore]
    public List<IEffect> givenEffects = new List<IEffect>();

    #endregion

    #region Methods
    public abstract int GetProficiencyRoll(ProficiencyType proficiencyType);

    public int GetPassiveProficiency(ProficiencyType proficiencyType)
    {
        return 10 + (this[(BaseStatTypes)proficiencyType] - 10) / 2;
    }
    public int GetStatRoll(BaseStatTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + (this[stat] - 10) / 2;
    }
    public virtual int GetSaveRoll(BaseStatTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + this[stat] - 10;
    }
    protected virtual void Heal(int heal)
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
        if (damage > _stats[StatTypes.CurrentHealth])
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
        int roll = Dice.Roll(DiceTypes.D20);
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
        _didAction = false;
        _didBonusAction = false;
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



    public abstract IExportable Import(string filePath);

    public abstract string ToXML();

    #endregion
}
