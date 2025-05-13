using System.Collections.Generic;

public class ElementsSingleton
{
    public List<ElementType> Elements { get => elements; }
    private List<ElementType> elements;

    private static ElementsSingleton instance;

    public static ElementsSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ElementsSingleton();
            }
            return instance;
        }
    }

    private ElementsSingleton() { }
    public void AddElement(ElementType element)
    {
        elements.Add(element);
    }
    public void AddElements(string[] filepaths)
    {
    }
    public static List<ElementType> ImportElements(string filePath)
    {
        // TODO implement importing from XML file
        return null;
    }
    public static void ExportElements(string filePath, List<ElementType> elements)
    {
        // TODO implement exporting to XML file
    }
}
