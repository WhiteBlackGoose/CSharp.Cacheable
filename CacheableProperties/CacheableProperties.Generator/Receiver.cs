using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace CacheableProperties.Generator
{
    internal sealed class Receiver : ISyntaxReceiver
    {
		public PropertyDeclarationSyntax Candidate { get; private set; }

		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is PropertyDeclarationSyntax propertyDeclarationSyntax)
			{
				if (
					propertyDeclarationSyntax.AttributeLists.Any(
						c => c.Attributes.Any(
							attr => 
							attr.Name.ToString() == "Cacheable" ||
							attr.Name.ToString() == "CacheableAttribute")
						))
					Candidate = propertyDeclarationSyntax;
			}
		}
	}
}
