namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeElement : IValidateElement, IElement
{
    public const string DEFAULT_DELIMITER = "$";
    public CodeLanguage Language { get; set; }
    public CodeKind Kind { get; set; }
    public string Delimiter { get; set; } = DEFAULT_DELIMITER;
    public string? Code { get; set; } = string.Empty;

    public void Deserialize(XElement? node)
    {
        if (node is null || node.Name != ElementNames.Code)
        {
            return;
        }

        #region Deserialize Attributes
        var attributes = node.Attributes().ToList();
        var languageAttribute = attributes.FirstOrDefault(a => a.Name == AttributeNames.Language);
        if (languageAttribute is not null)
        {
            Language = EnumHelper.GetCodeLanguage(languageAttribute.Value);
        }
        var kindAttribute = attributes.FirstOrDefault(a => a.Name == AttributeNames.Kind);
        if (kindAttribute is not null)
        {
            Kind = EnumHelper.GetCodeKind(kindAttribute.Value);
        }
        var delimiterAttribute = attributes.FirstOrDefault(a => a.Name == AttributeNames.Delimiter);
        if (delimiterAttribute is not null)
        {
            Delimiter = delimiterAttribute.Value;
        }
        #endregion

        XNode? childNode = node.FirstNode;
        if (childNode is XText t)
        {
            Code = t.Value;
        }
        else if (childNode is XCData c)
        {
            Code = c.Value;
        }
    }

    public XElement Serialize()
    {
        XElement e = new(ElementNames.Code);
        e.Add(new XAttribute(AttributeNames.Language, EnumHelper.GetString(Language)));
        if (Kind != CodeKind.Any)
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
        if (Language == CodeLanguage.None)
        {
            yield return new ValidationError(AttributeNames.Language.LocalName, "Language is mandatory in Code element");
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            yield return new ValidationError(ElementNames.Code.LocalName, "Code body cannot be empty. ");
        }
    }
}
