using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Attack : IExportable, IDamage
{
    string Name { get; set; }
    string _name;
    string Description { get; set; }

    public List<Damage> damages { get; set; }
    int Range { get; set; }
    int Radius { get; set; }
    bool isBonusAction { get; set; }
    bool isReaction { get; set; }
    public BaseStatTypes statType { get; set; }

    public Attack(string name, string description, List<Damage> damage, int range, int radius = 0, bool isBonusAction = false, bool isReaction = false)
    {
        Name = name;
        Description = description;
        damages = new List<Damage>();
        Range = range;
        Radius = radius;
        this.isBonusAction = isBonusAction;
        this.isReaction = isReaction;
    }
    public virtual int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in damages)
        {
            amount += roll.GetDamage();
        }
        return amount;
    }

    public void Export(string filePath, List<IExportable> exportables = null)
    {
        XmlSerializer xml = new XmlSerializer(typeof(Attack));

        using (TextWriter writer = new StreamWriter(filePath))
        {
            xml.Serialize(writer, this);
        }
    }

    public string ToXML()
    {
        throw new System.NotImplementedException();
    }

    public IExportable Import(string filePath)
    {
        Attack attack = new Attack();
        
    }
}
