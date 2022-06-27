﻿namespace Galaxism.CodeSnippets.VisualStudio;
public class CodeSnippetElement: IValidateElement, IElement
{
    public string Format { get; set; } = "1.0.0";
    public HeaderElement? Header { get; set; }
    public SnippetElement? Snippet { get; set; }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }

    public XElement Serialize()
    {
        XElement element = new(ElementNames.CodeSnippet);
        element.Add(new XAttribute(AttributeNames.Format, Format));
        if(Header != null)
        {
            element.Add(Header.Serialize());
        }
        if (Snippet != null)
        {
            element.Add(Snippet.Serialize());
        }
        return element;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(Format == null)
        {
            yield return new ValidationError(AttributeNames.Format, "Format must be a valid x.x.x format string. ");
        }
        if(Header is null)
        {
            yield return new ValidationError(ElementNames.Header, "Header is mandatory. ");
        }
        if(Snippet is null)
        {
            yield return new ValidationError(ElementNames.Snippet, "Snippet is mandatory. ");
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
