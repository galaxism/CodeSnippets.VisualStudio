namespace Galaxism.CodeSnippets.VisualStudio;
public interface IElement
{
    XElement? Serialize();
    void Deserialize(XElement node);
}
