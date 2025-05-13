using System;
using System.Xml.Serialization;
using System.Linq;

[Serializable]
public class UnitBaseStats
{
    public UnitBaseStats(int str, int dex, int con, int intel, int wis, int cha)
    {
        this[BaseStatTypes.Strength] = str;
        this[BaseStatTypes.Dexterity] = dex;
        this[BaseStatTypes.Constitution] = con;
        this[BaseStatTypes.Intelligence] = intel;
        this[BaseStatTypes.Wisdom] = wis;
        this[BaseStatTypes.Charisma] = cha;
    }

    private int[] _baseStats = new int[Enum.GetNames(typeof(BaseStatTypes)).Length];


    [XmlArray("UnitBaseStats")]
    [XmlArrayItem("BaseStat")]
    public StatEntry[] SerializableStats
    {
        get => _baseStats.Select((val, idx) => new StatEntry
        {
            Type = Enum.GetName(typeof(BaseStatTypes), idx),
            Value = val
        }).ToArray();
        set
        {
            foreach (var entry in value)
            {
                var stat = (BaseStatTypes)Enum.Parse(typeof(BaseStatTypes), entry.Type);
                _baseStats[(int)stat] = entry.Value;
            }
        }
    }

    [XmlIgnore]
    public int this[BaseStatTypes stat]
    {
        get => _baseStats[(int)stat];
        set => _baseStats[(int)stat] = value;
    }
}
