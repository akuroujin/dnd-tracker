using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Attack")]
public class Attack : IExportable, IDamage
{
    public Attack(string name, string description, List<Damage> damages, int range, int radius, bool isAction,
        bool isBonusAction, bool isReaction, BaseStatTypes statTypes)
    {
        Name = name;
        Description = description;
        Damages = damages;
        Range = range;
        Radius = radius;
        IsAction = isAction;
        IsReaction = isReaction;
        IsAction = isAction;
    }

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
    public string Name { get; init; }

    [XmlElement]
    public string Description { get; init; }


    [XmlArray("damages")]
    [XmlArrayItem("damage")]
    public List<Damage> Damages { get; init; }

    [XmlElement]
    public int Range { get; init; }


    [XmlElement]
    int Radius { get; init; }

    [XmlElement]
    public bool IsAction { get; init; }

    [XmlElement]
    public bool IsBonusAction { get; init; }

    [XmlElement]
    public bool IsReaction { get; init; }

    [XmlElement]
    public BaseStatTypes statType { get; set; }

    public virtual int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in Damages)
        {
            amount += roll.GetDamage();
        }
        return amount;
    }

    public string ToXML()
    {
        throw new System.NotImplementedException();
    }

    public IExportable Import(string filePath)
    {
        throw new System.NotImplementedException();
    }
}
