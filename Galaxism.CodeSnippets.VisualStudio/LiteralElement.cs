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
        e.Add(new XAttribute("Editable", Editable ? "true" : "false"));
        e.Add(new XElement("ID", ID));
        e.Add(new XElement("Default", Default));
        if (!string.IsNullOrWhiteSpace(Function))
        {
            e.Add(new XElement("Function", Function));
        }
        if (!string.IsNullOrWhiteSpace(ToolTip))
        {
            e.Add(new XElement("ToolTip", ToolTip));
        }
        return e;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(string.IsNullOrWhiteSpace(ID))
        {
            yield return new ValidationError("ID", "ID is mandatory in Literal. ");
        }
        if(string.IsNullOrWhiteSpace(Default))
        {
            yield return new ValidationError("Default", "Default is mandatory in Literal. ");
        }
    }
}
