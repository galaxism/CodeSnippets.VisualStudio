namespace Galaxism.CodeSnippets.VisualStudio;
public class LiteralElement : IValidateElement, IElement
{
    public bool Editable { get; set; } = true;
    public string? ID { get; set; }
    public string? ToolTip { get; set; }
    public string? Default { get; set; }
    public string? Function { get; set; }

    public void Deserialize(XElement? node)
    {
        if (node is null || node.Name != ElementNames.Literal) return;
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
        XElement e = new(ElementNames.Literal);
        e.Add(new XAttribute(AttributeNames.Editable, Editable ? "true" : "false"));
        e.Add(new XElement(ElementNames.Id, ID));
        e.Add(new XElement(ElementNames.Default, Default));
        if (!string.IsNullOrWhiteSpace(Function))
        {
            e.Add(new XElement(ElementNames.Function, Function));
        }
        if (!string.IsNullOrWhiteSpace(ToolTip))
        {
            e.Add(new XElement(ElementNames.ToolTip, ToolTip));
        }
        return e;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if (string.IsNullOrWhiteSpace(ID))
        {
            yield return new ValidationError(ElementNames.Id, "ID is mandatory in Literal. ");
        }
        if (string.IsNullOrWhiteSpace(Default))
        {
            yield return new ValidationError(ElementNames.Default, "Default is mandatory in Literal. ");
        }
    }
}
