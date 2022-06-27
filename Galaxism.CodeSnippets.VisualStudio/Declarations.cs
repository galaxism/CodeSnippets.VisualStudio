namespace Galaxism.CodeSnippets.VisualStudio;
public class Declarations : IValidateElement, IElement
{
    public List<LiteralElement> Literals { get; set; }
    public List<ObjectElement> Objects { get; set; }

    public Declarations()
    {
        Literals = new List<LiteralElement>();
        Objects = new List<ObjectElement>();
    }

    public void Add(params LiteralElement[] literals)
    {
        foreach (var literalElement in literals)
        {
            Literals.Add(literalElement);
        }
    }
    public void Add(params ObjectElement[] objectElements)
    {
        foreach (var objectElement in objectElements)
        {
            Objects.Add(objectElement);
        }
    }

    public IEnumerable<ValidationError> Validate()
    {
        if (Literals is not null && Literals.Count > 0)
        {
            foreach (var literal in Literals)
            {
                foreach (var item in literal.Validate())
                {
                    yield return item;
                }
            }
        }

        if (Objects is not null && Objects.Count > 0)
        {
            foreach (var @object in Objects)
            {
                foreach (var item in @object.Validate())
                {
                    yield return item;
                }
            }
        }
    }

    public XElement Serialize()
    {
        XElement e = new(ElementNames.Declarations);
        if (Literals is not null)
        {
            foreach (var literal in Literals)
            {
                e.Add(literal.Serialize());
            }
        }
        if (Objects is not null)
        {
            foreach (var @object in Objects)
            {
                e.Add(@object.Serialize());
            }
        }
        return e;
    }

    public void Deserialize(XElement? node)
    {
        Literals = new List<LiteralElement>();
        Objects = new List<ObjectElement>();
        if (node is null || node.Name != ElementNames.Declarations)
        {
            return;
        }
        var elements = node.Elements();
        foreach (var element in elements)
        {
            if (element.Name == ElementNames.Literal)
            {
                LiteralElement e = new();
                e.Deserialize(element);
                Literals.Add(e);
            }
            else if (element.Name == ElementNames.Object)
            {
                ObjectElement e = new();
                e.Deserialize(element);
                Objects.Add(e);
            }
        }
    }
}
