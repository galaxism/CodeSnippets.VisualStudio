namespace Galaxism.CodeSnippets.VisualStudio;
public class Declarations : IValidateElement, IElement
{
    public List<LiteralElement> Literals { get; }
    public List<ObjectElement> Objects { get; }

    public Declarations()
    {
        Literals = new List<LiteralElement>();
        Objects = new List<ObjectElement>();
    }

    public void Add(params LiteralElement[] literals)
    {
        foreach(var literalElement in literals)
        {
            Literals.Add(literalElement);
        }
    }
    public void Add(params ObjectElement[] objectElements)
    {
        foreach(var objectElement in objectElements)
        {
            Objects.Add(objectElement);
        }
    }

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

        if(Objects is not null && Objects.Count > 0)
        {
            foreach(var @object in Objects)
            {
                foreach(var item in @object.Validate())
                {
                    yield return item; 
                }
            }
        }
    }

    public XElement Serialize()
    {
        XElement e = new XElement(ElementNames.Declarations);
        foreach(var literal in Literals)
        {
            e.Add(literal.Serialize());
        }
        foreach(var @object in Objects)
        {
            e.Add(@object.Serialize());
        }
        return e;
    }

    public void Deserialize(XElement node)
    {
        throw new NotImplementedException();
    }
}
