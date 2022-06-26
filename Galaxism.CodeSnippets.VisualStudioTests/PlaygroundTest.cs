using Galaxism.CodeSnippets.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Galaxism.CodeSnippets.VisualStudio.Tests
{
    [TestClass]
    public class PlaygroundTest
    {
        [TestMethod]
        public void Test()
        {
            //XmlSerializer s = new XmlSerializer(typeof(CodeSnippetElement), "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet");
            //CodeSnippetElement e = new CodeSnippetElement();
            //e.Snippet = new SnippetElement()
            //{
            //    Code = new CodeElement() { Code="ABCD", Language= CodeLanguage.CSharp },
            //};
            //e.Snippet.Declarations.Add(new LiteralElement() { ID = "type", Default="int" });
            //e.Snippet.Declarations.Add(new ObjectElement());

            //e.Header = new HeaderElement() { Title = "Test" };
            //TextWriter writer = new StreamWriter("test.xml");

            //s.Serialize(writer, e);
            //writer.Close();

        }
    }
}
