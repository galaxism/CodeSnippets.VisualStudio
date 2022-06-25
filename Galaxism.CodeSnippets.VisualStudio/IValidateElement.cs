namespace Galaxism.CodeSnippets.VisualStudio;
public interface IValidateElement
{
    IEnumerable<ValidationError> Validate();
}
