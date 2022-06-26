using System.Xml.Serialization;

namespace Galaxism.CodeSnippets.VisualStudio;
public class HeaderElement: IValidateElement
{
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? HelpUrl { get; set; }
    public string? Shortcut { get; set; }
    public List<SnippetType> SnippetTypes { get; set; }
    public string? Title { get; set; }
    public List<string> Keywords { get; set; }
    public HeaderElement()
    {
        SnippetTypes = new List<SnippetType>();
        Keywords = new List<string>();
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(string.IsNullOrWhiteSpace(Title))
        {
            yield return new ValidationError("Title", "Title is mandatory in Header. ");
        }
    }
}
