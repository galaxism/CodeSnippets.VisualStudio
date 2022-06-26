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
    public class HeaderElementTests
    {
        [TestMethod()]
        [DynamicData(nameof(GetHeaders), DynamicDataSourceType.Method)]
        public void ValidateTest(string? title, int count)
        {
            HeaderElement e = new HeaderElement
            {
                Title = title,
            };
            var errors = e.Validate();
            Assert.AreEqual(count, errors.Count());
            Assert.IsNotNull(e.SnippetTypes);
            Assert.IsNotNull(e.Keywords);
        }

        public static IEnumerable<object?[]> GetHeaders()
        {
            yield return new object?[] { null, 1 };
            yield return new object?[] { string.Empty, 1 };
            yield return new object?[] { "1", 0 };
        }
    }
}