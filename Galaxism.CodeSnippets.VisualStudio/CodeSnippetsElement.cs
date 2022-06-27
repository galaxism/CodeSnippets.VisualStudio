namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeSnippetsElement : IValidateElement, IElement
{
    public List<CodeSnippetElement> CodeSnippets { get; private set; }
    public CodeSnippetsElement()
    {
        CodeSnippets = new List<CodeSnippetElement>();
    }
    public void Deserialize(XElement? node)
    {
        if (node is null || node.Name!= ElementNames.CodeSnippets) return;
        CodeSnippets.Clear();
        var elements = node.Elements(ElementNames.CodeSnippet).ToList();
        foreach(var element in elements)
        {
            CodeSnippetElement e = new();
            e.Deserialize(element);
            CodeSnippets.Add(e);
        }
    }

    public XElement Serialize()
    {
        string x = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet";
        XElement result = new(ElementNames.CodeSnippets);
        result.Add(new XAttribute("Xmlns", x));
        foreach(var element in CodeSnippets)
        {
            result.Add(element.Serialize());
        }
        return result;
    }

    public IEnumerable<ValidationError> Validate()
    {
        throw new NotImplementedException();
    }
}