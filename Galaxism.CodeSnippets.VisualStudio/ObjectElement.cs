namespace Galaxism.CodeSnippets.VisualStudio;
public class ObjectElement: IValidateElement
{
    public bool Editable { get; set; }
    public string? ID { get; set; }
    public string? Type { get; set; }
    public string? ToolTip { get; set; }
    public string? Default { get; set; }
    public string? Function { get; set; }

    public IEnumerable<ValidationError> Validate()
    {
        if(ID is null)
        {
            yield return new ValidationError("Object", "ID is mandatory in Object.");
        }
        if(Type is null)
        {
            yield return new ValidationError("Type", "Type is mandatory in Object.");
        }
        if(Default is null)
        {
            yield return new ValidationError("Default", "Default is mandatory in Object.");
        }
    }
}