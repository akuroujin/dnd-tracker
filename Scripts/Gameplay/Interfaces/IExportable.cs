using System.Collections.Generic;
using System.Xml;

public interface IExportable
{
    string ToXML();
    IExportable Import(string filePath);
}
