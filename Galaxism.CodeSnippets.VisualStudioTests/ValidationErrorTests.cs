using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxism.CodeSnippets.VisualStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxism.CodeSnippets.VisualStudio.Tests
{
    [TestClass()]
    public class ValidationErrorTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            ValidationError e1 = new ValidationError("1", "11");
            ValidationError e2 = new ValidationError("1", "11");
            Assert.IsTrue(e1.Equals(e2));
            Assert.IsTrue(e1.GetHashCode() == e2.GetHashCode());
        }
    }
}