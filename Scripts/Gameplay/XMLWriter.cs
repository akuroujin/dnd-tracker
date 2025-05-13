using System.Xml.Serialization;
using System.IO;
public static class XMLWriter
{
    public static void Export(string filePath, IExportable item)
    {
        XmlSerializer xml = new XmlSerializer(item.GetType());

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            xml.Serialize(writer, item);
        }
    }
}
