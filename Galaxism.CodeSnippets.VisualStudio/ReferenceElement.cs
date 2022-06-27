namespace Galaxism.CodeSnippets.VisualStudio;
public class ReferenceElement: IValidateElement, IElement
{
    private const string XmlElementName = "Reference";
    public string? Assembly { get; set; }
    public string? Url { get; set; }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }

    public XElement? Serialize()
    {
        if(string.IsNullOrWhiteSpace(Assembly) && string.IsNullOrWhiteSpace(Url))
        {
            return null;
        }
        XElement element = new(XmlElementName);
        element.Add(new XElement(ElementNames.Assembly, Assembly));
        if (!string.IsNullOrWhiteSpace(Url))
        {
            element.Add(new XElement("Url", Url));
        }
        return element;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if (string.IsNullOrWhiteSpace(Assembly))
        {
            yield return new ValidationError(nameof(Assembly), "Assembly is mandatory in Reference");
        }
    }
}
