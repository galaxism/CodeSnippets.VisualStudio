namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeSnippetElement: IValidateElement
{
    public string Format { get; set; } = "1.0.0";
    public HeaderElement? Header { get; set; }
    public SnippetElement? Snippet { get; set; }

    public IEnumerable<ValidationError> Validate()
    {
        if(Format == null)
        {
            yield return new ValidationError(nameof(Format), "Format must be a valid x.x.x format string. ");
        }
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
            foreach(var item in Header.Validate())
            {
                yield return item;
            }
        }
        if(Snippet is not null)
        {
            foreach(var item in Snippet.Validate())
            {
                yield return item;
            }
        }
    }
}
