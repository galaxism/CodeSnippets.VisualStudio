using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxism.CodeSnippets.VisualStudio
{
    public interface IElement
    {
        XElement Serialize();
        void Deserialize(XElement node);
    }
}
