namespace Galaxism.CodeSnippets.VisualStudio;
public class ReferenceElement: IValidateElement
{
    public string? Assembly { get; set; }
    public string? Url { get; set; }

    public IEnumerable<ValidationError> Validate()
    {
        yield break;
    }
}
