namespace Galaxism.CodeSnippets.VisualStudio;
public struct ValidationError
{
    public string ErrorMessage { get; set; } = string.Empty;
    public string ElementName { get; set; } = string.Empty;
    public ValidationError(string elementName, string errorMessage)
    {
        ErrorMessage = errorMessage;
        ElementName = elementName;
    }

    public override bool Equals(object obj)
    {
        if (obj is ValidationError e)
        {
            return ElementName == e.ElementName && ErrorMessage == e.ErrorMessage;
        }
        return false;
    }

    public override int GetHashCode() => ElementName.GetHashCode() ^ ErrorMessage.GetHashCode();

    public static bool operator ==(ValidationError left, ValidationError right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValidationError left, ValidationError right)
    {
        return !(left == right);
    }
}
