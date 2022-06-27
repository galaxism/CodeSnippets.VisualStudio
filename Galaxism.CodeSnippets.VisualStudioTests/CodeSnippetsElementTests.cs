using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxism.CodeSnippets.VisualStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Galaxism.CodeSnippets.VisualStudio.Tests
{
    [TestClass()]
    public class CodeSnippetsElementTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            CodeSnippetsElement element = new();
            element.CodeSnippets.Add(new CodeSnippetElement()
            {
                Header = new HeaderElement(),
                Snippet = new SnippetElement()
            });
            XElement e = element.Serialize();
            Console.WriteLine(e.ToString());
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            XDocument d = XDocument.Load("test.snippet");
            CodeSnippetsElement e = new CodeSnippetsElement();
            e.Deserialize(d.Root);

        }
    }
}