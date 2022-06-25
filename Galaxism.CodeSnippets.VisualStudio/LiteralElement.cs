using System.Xml.Serialization;

namespace Galaxism.CodeSnippets.VisualStudio;
public class LiteralElement: IValidateElement
{
    public string? ID { get; set; }
    public string? ToolTip { get; set; }
    public string? Default { get; set; }
    public string? Function { get; set; }

    public IEnumerable<ValidationError> Validate()
    {
        if(ID is null)
        {
            yield return new ValidationError("ID", "ID is mandatory in Literal. ");
        }
        if(Default is null)
        {
            yield return new ValidationError("Default", "Default is mandatory in Literal. ");
        }
    }
}
