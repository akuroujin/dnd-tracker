using System.Collections.Generic;

public class ElementCollection
{
    public List<Element> elements = new List<Element>();


    public void AddElement(Element element)
    {
        elements.Add(element);
    }
}