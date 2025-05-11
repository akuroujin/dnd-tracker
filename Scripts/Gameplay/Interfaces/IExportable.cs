using System.Collections.Generic;
using System.Xml;

public interface IExportable
{
    void Export(string filePath, List<IExportable> exportables = null);
    string ToXML();
    IExportable Import(string filePath);
}
