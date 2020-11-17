using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CacheableProperties.Generator
{
    internal sealed class Builder
    {
        private IPropertySymbol symbol;
        public Builder(IPropertySymbol sourceSymbol)
        {
            symbol = sourceSymbol;
        }

        public SourceText ToSourceText()
        {
            using var writer = new StringWriter();
            using var indentWriter = new IndentedTextWriter(writer, "	");
            throw new NotImplementedException();
        }
    }
}
