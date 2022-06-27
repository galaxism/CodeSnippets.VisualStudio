namespace Galaxism.CodeSnippets.VisualStudio;
public class SnippetElement: IValidateElement, IElement
{
    public CodeElement? Code { get; set; }
    public Declarations Declarations { get; }
    public List<string> Imports { get; }
    public List<ReferenceElement> References { get; }

    public SnippetElement()
    {
        Imports = new List<string>();
        Declarations = new Declarations();
        References= new List<ReferenceElement>();
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(Code is null)
        {
            yield return new ValidationError(ElementNames.Code, "Code is mandatory in Snippet. ");
        }
        if(Code is not null)
        {
            foreach(var item in Code.Validate())
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
        
        if(References.Count > 0)
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

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }
}
