namespace Galaxism.CodeSnippets.VisualStudio;
public class SnippetElement: IValidateElement, IElement
{
    public CodeElement? Code { get; set; }
    public DeclarationCollection Declarations { get; }
    public List<string> Imports { get; }
    public List<ReferenceElement> References { get; }

    public SnippetElement()
    {
        Imports = new List<string>();
        Declarations = new DeclarationCollection();
        References= new List<ReferenceElement>();
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(Code is null)
        {
            yield return new ValidationError("Code", "Code is mandatory in Snippet. ");
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
        XElement e = new("CodeSnippet");
        if (Code != null)
        {
            e.Add(Code.Serialize());
        }
        if (Declarations.Literals.Count + Declarations.Objects.Count > 0)
        {
            XElement declarations = new("Declarations");
            foreach (var literal in Declarations.Literals)
            {
                declarations.Add(literal.Serialize());
            }
            foreach (var objectObject in Declarations.Objects)
            {
                declarations.Add(objectObject.Serialize());
            }
            e.Add(declarations);
        }
        if (Imports.Count > 0)
        {
            XElement imports = new("Imports");
            foreach(var import in Imports)
            {
                XElement importElement = new("Import", new XElement("Namespace", import));
                imports.Add(importElement);
            }
            e.Add(imports);
        }

        return e;
    }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }
}
