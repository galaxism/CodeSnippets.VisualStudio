namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeSnippetElement: IValidateElement
{
    public string Format { get; set; } = "1.0.0";
    public HeaderElement? Header { get; set; }
    public SnippetElement? Snippet { get; set; }

    public IEnumerable<ValidationError> Validate()
    {
        if(Header is null)
        {
            yield return new ValidationError("Header", "Header is mandatory. ");
        }
        if(Snippet is null)
        {
            yield return new ValidationError("Snippet", "Snippet is mandatory. ");
        }
        if(Header is not null)
        {
            
        }
        if(Snippet is not null)
        {
            
        }
    }
}
