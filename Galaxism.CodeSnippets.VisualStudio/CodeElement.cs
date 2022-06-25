namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeElement: IValidateElement
{
    public CodeLanguage Language { get; set; }
    public CodeKind Kind { get; set; }
    public string Delimiter { get; set; } = "$";
    public string Code { get; set; } = string.Empty;

    public IEnumerable<ValidationError> Validate()
    {
        yield break;
    }
}
