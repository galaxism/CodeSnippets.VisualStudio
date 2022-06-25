namespace Galaxism.CodeSnippets.VisualStudio;
public class SnippetElement: IValidateElement
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
}
