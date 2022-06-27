namespace Galaxism.CodeSnippets.VisualStudio;

public static class ElementNames
{
    private const string Local_Assembly = "Assembly";
    private const string Local_Author = "Author";
    private const string Local_Code = "Code";
    private const string Local_CodeSnippet = "CodeSnippet";
    private const string Local_CodeSnippets = "CodeSnippets";
    private const string Local_Declarations = "Declarations";
    private const string Local_Default = "Default";
    private const string Local_Description = "Description";
    private const string Local_Function = "Function";
    private const string Local_Header = "Header";
    private const string Local_HelpUrl = "HelpUrl";
    private const string Local_Id = "ID";
    private const string Local_Import = "Import";
    private const string Local_Imports = "Imports";
    private const string Local_Keyword = "Keyword";
    private const string Local_Keywords = "Keywords";
    private const string Local_Literal = "Literal";
    private const string Local_Namespace = "Namespace";
    private const string Local_Object = "Object";
    private const string Local_Reference = "Reference";
    private const string Local_References = "References";
    private const string Local_Shortcut = "Shortcut";
    private const string Local_Snippet = "Snippet";
    private const string Local_SnippetType = "SnippetType";
    private const string Local_SnippetTypes = "SnippetTypes";
    private const string Local_Title = "Title";
    private const string Local_ToolTip = "ToolTip";
    private const string Local_Type = "Type";
    private const string Local_Url = "Url";

    public static readonly XName Assembly = ElementHelper.GetXName(Local_Assembly);
    public static readonly XName Author = ElementHelper.GetXName(Local_Author);
    public static readonly XName Code = ElementHelper.GetXName(Local_Code);
    public static readonly XName CodeSnippet = ElementHelper.GetXName(Local_CodeSnippet);
    public static readonly XName CodeSnippets = ElementHelper.GetXName(Local_CodeSnippets);
    public static readonly XName Declarations = ElementHelper.GetXName(Local_Declarations);
    public static readonly XName Default = ElementHelper.GetXName(Local_Default);
    public static readonly XName Description = ElementHelper.GetXName(Local_Description);
    public static readonly XName Function = ElementHelper.GetXName(Local_Function);
    public static readonly XName Header = ElementHelper.GetXName(Local_Header);
    public static readonly XName HelpUrl = ElementHelper.GetXName(Local_HelpUrl);
    public static readonly XName Id = ElementHelper.GetXName(Local_Id);
    public static readonly XName Import = ElementHelper.GetXName(Local_Import);
    public static readonly XName Imports = ElementHelper.GetXName(Local_Imports);
    public static readonly XName Keyword = ElementHelper.GetXName(Local_Keyword);
    public static readonly XName Keywords = ElementHelper.GetXName(Local_Keywords);
    public static readonly XName Literal = ElementHelper.GetXName(Local_Literal);
    public static readonly XName Namespace = ElementHelper.GetXName(Local_Namespace);
    public static readonly XName Object = ElementHelper.GetXName(Local_Object);
    public static readonly XName Reference = ElementHelper.GetXName(Local_Reference);
    public static readonly XName References = ElementHelper.GetXName(Local_References);
    public static readonly XName Shortcut = ElementHelper.GetXName(Local_Shortcut);
    public static readonly XName Snippet = ElementHelper.GetXName(Local_Snippet);
    public static readonly XName SnippetType = ElementHelper.GetXName(Local_SnippetType);
    public static readonly XName SnippetTypes = ElementHelper.GetXName(Local_SnippetTypes);
    public static readonly XName Title = ElementHelper.GetXName(Local_Title);
    public static readonly XName ToolTip = ElementHelper.GetXName(Local_ToolTip);
    public static readonly XName Type = ElementHelper.GetXName(Local_Type);
    public static readonly XName Url = ElementHelper.GetXName(Local_Url);
}

public static class AttributeNames
{
    private const string Local_Language = "Language";
    private const string Local_Kind = "Kind";
    private const string Local_Delimiter = "Delimiter";
    private const string Local_Format = "Format";
    private const string Local_Editable = "Editable";

    public static readonly XName Language = XName.Get(Local_Language);
    public static readonly XName Kind = XName.Get(Local_Kind);
    public static readonly XName Format = XName.Get(Local_Format);
    public static readonly XName Editable = XName.Get(Local_Editable);
    public static readonly XName Delimiter = XName.Get(Local_Delimiter);
}