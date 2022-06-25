namespace Galaxism.CodeSnippets.VisualStudio;
public class DeclarationCollection: IValidateElement
{
    public List<LiteralElement> Literals { get; }
    public List<ObjectElement> Objects { get; }

    public DeclarationCollection()
    {
        Literals = new List<LiteralElement>();
        Objects = new List<ObjectElement>();
    }

    public void Add(LiteralElement literal) => Literals.Add(literal);
    public void Add(ObjectElement objectElement) => Objects.Add(objectElement);

    public IEnumerable<ValidationError> Validate()
    {
        if(Literals is not null && Literals.Count > 0)
        {
            foreach(var literal in Literals)
            {
                foreach(var item in literal.Validate())
                {
                    yield return item;
                }
            }
        }
    }
}
