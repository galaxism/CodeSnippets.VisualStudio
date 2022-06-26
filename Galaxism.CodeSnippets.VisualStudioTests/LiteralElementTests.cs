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
    public class LiteralElementTests
    {
        [TestMethod()]
        [DynamicData(nameof(GetValidationSource), DynamicDataSourceType.Method)]
        public void ValidateTest(string? id, string? @default, string? tooltip, string? function, int count)
        {
            LiteralElement e = new LiteralElement() {
                ID = id,
                Default = @default,
                ToolTip = tooltip,
                Function = function,
            };
            var errors = e.Validate();
            Assert.AreEqual(count, errors.Count());
        }

        public static IEnumerable<object?[]> GetValidationSource()
        {
            yield return new object?[] { null, null, null, null, 2 };
            yield return new object?[] { string.Empty, string.Empty, string.Empty, string.Empty, 2 };
            yield return new object?[] { "1", "1", null, null, 0 };
            yield return new object?[] { "1", null, null, null, 1 };
            yield return new object?[] { null, "1", null, null, 1 };
            yield return new object?[] { null, null, "1", "1", 2 };
        }
    }
}