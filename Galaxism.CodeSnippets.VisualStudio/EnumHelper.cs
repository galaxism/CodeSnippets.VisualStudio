using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxism.CodeSnippets.VisualStudio
{
    public static class EnumHelper
    {
        #region CodeLanguage
        private static readonly Dictionary<string, CodeLanguage> _codeLanguages = new Dictionary<string, CodeLanguage>
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
        private static readonly Dictionary<string, CodeKind> _codeKinds = new Dictionary<string, CodeKind>
        {
            ["any"] = CodeKind.Any,
            ["method body"] = CodeKind.MethodBody,
            ["method decl"] = CodeKind.MethodDeclaration,
            ["type decl"] = CodeKind.TypeDeclaration,
            ["file"] = CodeKind.File,
        };
        private static readonly Dictionary<CodeKind, string> _kindsToString = new Dictionary<CodeKind, string>
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
        #endregion

    }
}
