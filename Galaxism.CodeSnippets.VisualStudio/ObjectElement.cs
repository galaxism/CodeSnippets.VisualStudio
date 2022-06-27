namespace Galaxism.CodeSnippets.VisualStudio;
public class ObjectElement : IValidateElement, IElement
{
    public bool Editable { get; set; }
    public string? ID { get; set; }
    public string? Type { get; set; }
    public string? ToolTip { get; set; }
    public string? Default { get; set; }
    public string? Function { get; set; }

    public void Deserialize(XElement? node)
    {
        if (node is null || node.Name != ElementNames.Object) return;
        var elements = node.Descendants();
        ID = elements.GetTextByName(ElementNames.Id);
        ToolTip = elements.GetTextByName(ElementNames.ToolTip);
        Default = elements.GetTextByName(ElementNames.Default);
        Function = elements.GetTextByName(ElementNames.Function);
        var attribute = node.Attribute(AttributeNames.Editable);
        if (attribute is not null)
        {
            Editable = !bool.TryParse(attribute.Value, out bool b) || b;
        }
    }

    public XElement Serialize()
    {
        XElement element = new(ElementNames.Object);
        element.Add(new XElement(ElementNames.Id, ID));
        element.Add(new XElement(ElementNames.Type, Type));
        element.Add(new XElement(ElementNames.Default, Default));
        if (!string.IsNullOrWhiteSpace(ToolTip))
        {
            element.Add(new XElement(ElementNames.ToolTip, ToolTip));
        }
        if (!string.IsNullOrWhiteSpace(Function))
        {
            element.Add(new XElement(ElementNames.Function, Function));
        }
        return element;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if (ID is null)
        {
            yield return new ValidationError("Object", "ID is mandatory in Object.");
        }
        if (Type is null)
        {
            yield return new ValidationError("Type", "Type is mandatory in Object.");
        }
        if (Default is null)
        {
            yield return new ValidationError("Default", "Default is mandatory in Object.");
        }
    }
}