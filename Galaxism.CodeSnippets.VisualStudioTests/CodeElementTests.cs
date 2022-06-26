using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxism.CodeSnippets.VisualStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxism.CodeSnippets.VisualStudio.Tests
{
    [TestClass()]
    public class CodeElementTests
    {
        [TestMethod()]
        [DynamicData(nameof(GetCodes), DynamicDataSourceType.Method)]
        public void ValidateTest(CodeLanguage language, string? code, int count)
        {
            CodeElement e = new CodeElement()
            {
                Language = language,
                Code = code,
            };
            var errors = e.Validate();
            Assert.AreEqual(count, errors.Count());
        }

        public static IEnumerable<object?[]> GetCodes()
        {
            yield return new object?[] { CodeLanguage.None, null, 2 };
            yield return new object?[] { CodeLanguage.None, string.Empty, 2 };
            yield return new object?[] { CodeLanguage.CSharp, string.Empty, 1 };
            yield return new object?[] { CodeLanguage.None, "1", 1 };
            yield return new object?[] { CodeLanguage.CSharp, "1", 0 };

        }
    }
}