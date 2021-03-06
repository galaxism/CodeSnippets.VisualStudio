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
        XElement result = new(ElementNames.CodeSnippets);
        foreach(var element in CodeSnippets)
        {
            result.Add(element.Serialize());
        }
        return result;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(CodeSnippets is not null && CodeSnippets.Count > 0)
        {
            foreach(var codeSnippet in CodeSnippets)
            {
                var errors = codeSnippet.Validate();
                foreach(var error in errors)
                {
                    yield return error;
                }
            }
        }
    }
}