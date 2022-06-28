namespace Galaxism.CodeSnippets.VisualStudio;
public class SnippetDocument
{
    public CodeSnippetsElement CodeSnippets { get; }

    public SnippetDocument()
    {
        CodeSnippets = new CodeSnippetsElement();
    }

    public static SnippetDocument Load(string uri, LoadOptions option = LoadOptions.None)
    {
        SnippetDocument document = new();
        XDocument d = XDocument.Load(uri, option);
        document.CodeSnippets.Deserialize(d.Root);
        return document;
    }

    public static SnippetDocument Load(XmlReader reader, LoadOptions option = LoadOptions.None)
    {
        SnippetDocument document = new();
        XDocument d = XDocument.Load(reader, option);
        document.CodeSnippets.Deserialize(d.Root);
        return document;
    }

    public static SnippetDocument Load(TextReader reader, LoadOptions option = LoadOptions.None)
    {
        SnippetDocument document = new();
        XDocument d = XDocument.Load(reader, option);
        document.CodeSnippets.Deserialize(d.Root);
        return document;
    }

    public static SnippetDocument Load(Stream reader, LoadOptions option = LoadOptions.None)
    {
        SnippetDocument document = new();
        XDocument d = XDocument.Load(reader, option);
        document.CodeSnippets.Deserialize(d.Root);
        return document;
    }

    public static SnippetDocument Parse(string text, LoadOptions option = LoadOptions.None)
    {
        SnippetDocument document = new();
        XDocument d = XDocument.Parse(text, option);
        document.CodeSnippets.Deserialize(d.Root);
        return document;
    }

    public void Save(TextWriter writer, SaveOptions option = SaveOptions.None)
    {
        XDocument document = new();
        document.Add(CodeSnippets.Serialize());
        document.Save(writer, option);
    }

    public void Save(string fileName, SaveOptions option = SaveOptions.None)
    {
        XDocument document = new();
        document.Add(CodeSnippets.Serialize());
        document.Save(fileName, option);
    }

    public void Save(Stream stream, SaveOptions option = SaveOptions.None)
    {
        XDocument document = new();
        document.Add(CodeSnippets.Serialize());
        document.Save(stream, option);
    }

    public override string ToString()
    {
        XDocument document = new();
        document.Add(CodeSnippets.Serialize());
        return document.ToString();
    }

    public string ToString(SaveOptions options)
    {
        XDocument document = new();
        document.Add(CodeSnippets.Serialize());
        return document.ToString(options);
    }
}
