namespace Galaxism.CodeSnippets.VisualStudio;
public class SnippetElement : IValidateElement, IElement
{
    public CodeElement? Code { get; set; }
    public Declarations Declarations { get; private set; }
    public List<string> Imports { get; private set; }
    public List<ReferenceElement> References { get; private set; }

    public SnippetElement()
    {
        Imports = new List<string>();
        Declarations = new Declarations();
        References = new List<ReferenceElement>();
    }

    public IEnumerable<ValidationError> Validate()
    {
        if (Code is null)
        {
            yield return new ValidationError(ElementNames.Code, "Code is mandatory in Snippet. ");
        }
        if (Code is not null)
        {
            foreach (var item in Code.Validate())
            {
                yield return item;
            }
        }

    }

    public XElement Serialize()
    {
        XElement e = new(ElementNames.Snippet);
        e.Add(Declarations.Serialize());
        if (Imports.Count > 0)
        {
            XElement imports = new(ElementNames.Imports);
            foreach (var import in Imports)
            {
                XElement importElement = new(ElementNames.Import, new XElement(ElementNames.Namespace, import));
                imports.Add(importElement);
            }
            e.Add(imports);
        }
        if (Code != null)
        {
            e.Add(Code.Serialize());
        }

        if (References.Count > 0)
        {
            XElement referencesElement = new(ElementNames.References);
            int count = 0;
            foreach (var reference in References)
            {
                XElement? referenceElement = reference.Serialize();
                if (referenceElement is not null)
                {
                    referencesElement.Add(referenceElement);
                    count++;
                }
            }
            if (count > 0)
            {
                e.Add(referencesElement);
            }
        }
        return e;
    }

    public void Deserialize(XElement? node)
    {
        if (node is null || node.Name != ElementNames.Snippet) return;
        var elements = node.Descendants();
        var codeElement = elements.FirstOrDefault(a => a.Name == ElementNames.Code);
        Code = new();
        Code.Deserialize(codeElement);
        var declarationsElement = elements.FirstOrDefault(a => a.Name == ElementNames.Declarations);
        Declarations = new();
        Declarations.Deserialize(declarationsElement);
        var referencesElement = elements.FirstOrDefault(a => a.Name == ElementNames.References);
        DeserializeReferences(referencesElement);
        var importsElement = elements.FirstOrDefault(a => a.Name == ElementNames.Imports);
        DeserializeImports(importsElement);
    }

    private void DeserializeReferences(XElement? e)
    {
        References = new List<ReferenceElement>();
        if (e is null) return;
        var elements = e.Descendants().Where(a => a.Name == ElementNames.Reference);
        foreach (var element in elements)
        {
            ReferenceElement re = new();
            re.Deserialize(element);
            if (re.Assembly != null && re.Url != null)
            {
                References.Add(re);
            }
        }
    }

    private void DeserializeImports(XElement? e)
    {
        Imports = new List<string>();
        if (e is null) return;
        var elements = e.Descendants();
        foreach (var element in elements)
        {
            if (element.Name == ElementNames.Import
                && element.FirstNode is XElement ie
                && ie.Name == ElementNames.Namespace
                && ie.FirstNode is XText t)
            {
                Imports.Add(t.Value);
            }
        }
    }
}
