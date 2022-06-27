namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeElement: IValidateElement, IElement
{
    public const string DEFAULT_DELIMITER = "$";
    public CodeLanguage Language { get; set; }
    public CodeKind Kind { get; set; }
    public string Delimiter { get; set; } = DEFAULT_DELIMITER;
    public string? Code { get; set; } = string.Empty;

    public void Deserialize(XElement node)
    {
              
    }

    public XElement Serialize()
    {
        XElement e = new(ElementNames.Code);
        e.Add(new XAttribute(AttributeNames.Language, EnumHelper.GetString(Language)));
        if(Kind!= CodeKind.Any)
        {
            e.Add(new XAttribute(AttributeNames.Kind, EnumHelper.GetString(Kind)));
        }
        if (!string.IsNullOrWhiteSpace(Delimiter) && Delimiter != DEFAULT_DELIMITER)
        {
            e.Add(new XAttribute(AttributeNames.Delimiter, Delimiter));
        }
        e.Add(new XCData(Code));
        return e;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(Language == CodeLanguage.None)
        {
            yield return new ValidationError(AttributeNames.Language, "Language is mandatory in Code element");
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            yield return new ValidationError(ElementNames.Code, "Code body cannot be empty. ");
        }
    }
}
