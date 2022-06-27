using System.Xml.Linq;
namespace Galaxism.CodeSnippets.VisualStudio;
public class LiteralElement: IValidateElement, IElement
{
    private const string XmlElementName = "Literal";
    public bool Editable { get; set; } = true;
    public string? ID { get; set; }
    public string? ToolTip { get; set; }
    public string? Default { get; set; }
    public string? Function { get; set; }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }

    public XElement Serialize()
    {
        XElement e = new(XmlElementName);
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
        if(string.IsNullOrWhiteSpace(ID))
        {
            yield return new ValidationError(ElementNames.Id, "ID is mandatory in Literal. ");
        }
        if(string.IsNullOrWhiteSpace(Default))
        {
            yield return new ValidationError(ElementNames.Default, "Default is mandatory in Literal. ");
        }
    }
}
