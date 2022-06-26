using System.Xml.Linq;
namespace Galaxism.CodeSnippets.VisualStudio;
public class LiteralElement: IValidateElement, IElement
{
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
        throw new NotImplementedException();
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
