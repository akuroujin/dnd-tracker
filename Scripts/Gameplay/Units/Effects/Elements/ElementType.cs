using System.Collections.Generic;
using Godot;
using System.Xml.Serialization;

[XmlRoot]
public class ElementType : IExportable
{
    [XmlElement]
    public string Name { get; set; }
    [XmlElement]
    public string Description { get; set; }
    [XmlElement]
    public int Duration { get; set; }
    [XmlElement]
    public Damage damage { get; set; }
    [XmlElement]
    public int MaxStacks { get; set; }

    public IExportable Import(string filePath)
    {
        throw new System.NotImplementedException();
    }

    public string ToXML()
    {
        throw new System.NotImplementedException();
    }
}
