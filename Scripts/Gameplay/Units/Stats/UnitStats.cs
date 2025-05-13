using System;
using System.Xml.Serialization;
using System.Linq;

[Serializable]
public class UnitStats
{
    public UnitStats(int maxUbi, int maxHealth, int walkspeed, int armorClass)
    {
        this[StatTypes.MaxUbi] = maxUbi;
        this[StatTypes.MaxHealth] = maxHealth;
        this[StatTypes.WalkSpeed] = walkspeed;
        this[StatTypes.Armorclass] = armorClass;
        this[StatTypes.CurrentUbi] = maxUbi;
        this[StatTypes.CurrentHealth] = maxHealth;
        this[StatTypes.TempHealth] = 0;
        this[StatTypes.Initiative] = 0;
    }

    private int[] _stats = new int[Enum.GetNames(typeof(StatTypes)).Length];

    [XmlArray("Stats")]
    [XmlArrayItem("Stat")]
    public StatEntry[] SerializableStats
    {
        get => _stats.Select((val, idx) => new StatEntry
        {
            Type = Enum.GetName(typeof(StatTypes), idx),
            Value = val
        }).ToArray();
        set
        {
            foreach (var entry in value)
            {
                var stat = (StatTypes)Enum.Parse(typeof(StatTypes), entry.Type);
                _stats[(int)stat] = entry.Value;
            }
        }
    }

    [XmlIgnore]
    public int this[StatTypes stat]
    {
        get => _stats[(int)stat];
        set => _stats[(int)stat] = value;
    }
}
