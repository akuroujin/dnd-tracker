using System.Xml.Serialization;


public class StatEntry
{
    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlText]
    public int Value { get; set; }
}
