namespace Galaxism.CodeSnippets.VisualStudio;
internal static class ElementHelper
{
    /// <summary>
    /// Return the text value of first node matching provided name. If no such a node, return <c>null</c>.
    /// </summary>
    /// <param name="elements"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    internal static string? GetTextByName(this IEnumerable<XElement> elements, XName name)
    {
        var element = elements.FirstOrDefault(a => a.Name == name);
        if (element is not null && element.FirstNode is XText t)
        {
            return t.Value;
        }
        else
        {
            return null;
        }
    }

    public const string CodeSnippetNamespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet";

    internal static XName GetXName(string s)
    {
        return XName.Get(s, CodeSnippetNamespace);
    }
}
