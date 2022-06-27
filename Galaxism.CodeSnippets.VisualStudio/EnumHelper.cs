namespace Galaxism.CodeSnippets.VisualStudio
{
    public static class EnumHelper
    {
        #region CodeLanguage
        private static readonly Dictionary<string, CodeLanguage> _codeLanguages = new()
        {
            ["VB"] = CodeLanguage.VB,
            ["CSharp"] = CodeLanguage.CSharp,
            ["CPP"] = CodeLanguage.CPP,
            ["XAML"] = CodeLanguage.XAML,
            ["XML"] = CodeLanguage.XML,
            ["JavaScript"] = CodeLanguage.JavaScript,
            ["TypeScript"] = CodeLanguage.TypeScript,
            ["SQL"] = CodeLanguage.SQL,
            ["HTML"] = CodeLanguage.HTML,

        };
        public static string GetString(CodeLanguage language)
        {
            return language.ToString();
        }
        public static CodeLanguage GetCodeLanguage(string language) => _codeLanguages.TryGetValue(language, out var codeLanguage) ? codeLanguage : CodeLanguage.None;
        #endregion

        #region CodeKind
        private static readonly Dictionary<string, CodeKind> _codeKinds = new()
        {
            ["any"] = CodeKind.Any,
            ["method body"] = CodeKind.MethodBody,
            ["method decl"] = CodeKind.MethodDeclaration,
            ["type decl"] = CodeKind.TypeDeclaration,
            ["file"] = CodeKind.File,
        };
        private static readonly Dictionary<CodeKind, string> _kindsToString = new()
        {
            [CodeKind.Any] = "any",
            [CodeKind.TypeDeclaration] = "type decl",
            [CodeKind.MethodBody] = "method body",
            [CodeKind.MethodDeclaration] = "method decl",
            [CodeKind.File] = "file",
        };
        public static string GetString(CodeKind kind)
        {
            return _kindsToString.TryGetValue(kind, out string v) ? v : string.Empty;
        }
        public static CodeKind GetCodeKind(string s)
        {
            return _codeKinds.TryGetValue(s, out CodeKind k) ? k : CodeKind.Any;
        }
        #endregion

        #region SnippetType
        private static readonly Dictionary<string, SnippetType> _snippetTypes = new()
        {
            ["SurroundsWith"] = SnippetType.SurroundsWith,
            ["Expansion"] = SnippetType.Expansion,
            ["Refactoring"] = SnippetType.Refactoring,
        };

        public static string GetString(SnippetType type)
        {
            return type.ToString();
        }
        public static SnippetType GetCodeSnippetType(string s)
        {
            return _snippetTypes.TryGetValue(s, out var t) ? t : SnippetType.None;
        }
        #endregion
    }
}
