using Galaxism.CodeSnippets.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
            CodeSnippetElement codeSnippet = new CodeSnippetElement();
            codeSnippet.Header = new HeaderElement
            {
                Title = "Define a DependencyProperty",
                Shortcut = "propdp",
                Description = "Code snippet for a property using DependencyProperty as the backing store",
                Author = "Microsoft Corporation",
                SnippetTypes = new List<SnippetType> { SnippetType.Expansion}
            };
            codeSnippet.Snippet = new SnippetElement();
            codeSnippet.Snippet.Code = new CodeElement()
            {
                Code = @"
public $type$ $property$
{
    get { return ($type$)GetValue($property$Property); }
    set { SetValue($property$Property, value); }
}

// Using a DependencyProperty as the backing store for $property$.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty $property$Property = 
    DependencyProperty.Register(""$property$"", typeof($type$), typeof($ownerclass$), new PropertyMetadata($defaultvalue$));

$end$",
                Language = CodeLanguage.CSharp,
            };
            codeSnippet.Snippet.Declarations.Add(
                new LiteralElement[] { 
                    new LiteralElement() { ID = "type", Default = "int", ToolTip = "Property Type"},
                    new LiteralElement() { ID = "property", Default = "MyProperty", ToolTip = "Property Name"},
                    new LiteralElement() { ID = "ownerclass", Default = "ownerclass", ToolTip = "The owning class of this Property.  Typically the class that it is declared in."},
                    new LiteralElement() { ID = "defaultvalue", Default = "0", ToolTip = "The default value for this property."}
                }
                );


            XElement e = codeSnippet.Serialize();
            Console.WriteLine(e.ToString());
        }
    }
}
