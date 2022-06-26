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
    public class CodeSnippetElementTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            CodeSnippetElement e = new CodeSnippetElement();
            var errors = e.Validate();
            Assert.AreEqual(2, errors.Count());
        }
    }
}