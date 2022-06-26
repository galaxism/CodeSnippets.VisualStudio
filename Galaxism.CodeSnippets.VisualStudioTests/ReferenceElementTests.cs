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
    public class ReferenceElementTests
    {
        [TestMethod()]
        [DynamicData(nameof(GetReferences), DynamicDataSourceType.Method)]
        public void ValidateTest(string? assembly, string? url, int count)
        {
            ReferenceElement e = new ReferenceElement()
            {
                Assembly = assembly,
                Url = url,
            };
            var errors = e.Validate();
            Assert.AreEqual(count, errors.Count());
        }

        public static IEnumerable<object?[]> GetReferences()
        {
            yield return new object?[] { null, null, 1 };
            yield return new object?[] { string.Empty, string.Empty, 1 };
            yield return new object?[] { "1", null, 0 };
            yield return new object?[] { null, "1", 1 };
        }
    }
}