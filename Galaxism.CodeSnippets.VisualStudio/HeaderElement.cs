using System.Xml.Serialization;

namespace Galaxism.CodeSnippets.VisualStudio;
public class HeaderElement: IValidateElement, IElement
{
    public string? Title { get; set; }
    /// <summary>
    /// Optional element. The name of the person or company that authored the code snippet. There may be zero or one <c>Author</c> elements in a <c>Header</c> element.
    /// </summary>
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? HelpUrl { get; set; }
    public string? Shortcut { get; set; }
    /// <summary>
    /// Groups of <c>Snippet</c> elements. If <c>SnippetType</c> is not present, the code snippet can be inserted anywhere in the code.
    /// </summary>
    public List<SnippetType> SnippetTypes { get; set; }
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

    public XElement Serialize()
    {
        XElement element = new("Header");
        element.Add(new XElement("Title", Title));

        // These three elements are optional, but can be helpful to included in exported documents. 
        element.Add(new XElement("Shortcut", Shortcut));
        element.Add(new XElement("Author", Author));
        element.Add(new XElement("Description", Description));
        if (!string.IsNullOrWhiteSpace(HelpUrl))
        {
            element.Add(new XElement("HelpUrl", HelpUrl));
        }

        // Add Snippet Type if any
        var types = SnippetTypes?.Where(a => a != SnippetType.None).ToList();
        if(types != null && types.Count > 0)
        {
            XElement snippetArray = new("SnippetTypes");
            foreach(var snippetType in types)
            {
                if(snippetType != SnippetType.None)
                {
                    snippetArray.Add(new XElement("SnippetType", EnumHelper.GetString(snippetType)));
                }
            }
        }
        if(Keywords is not null && Keywords.Count > 0)
        {
            XElement keywordsArray = new("Keywords");
            foreach(var keyword in Keywords)
            {
                keywordsArray.Add(new XElement("Keyword", keyword));
            }
        }

        return element;
    }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }

}
