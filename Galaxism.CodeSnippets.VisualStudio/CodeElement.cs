namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeElement: IValidateElement, IElement
{
    public const string XmlElementName = "Code";
    public CodeLanguage Language { get; set; }
    public CodeKind Kind { get; set; }
    public string Delimiter { get; set; } = "$";
    public string? Code { get; set; } = string.Empty;

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
        if(Language == CodeLanguage.None)
        {
            yield return new ValidationError(nameof(Language), "Language is mandatory in Code element");
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            yield return new ValidationError(nameof(Code), "Code body cannot be empty. ");
        }
    }
}
