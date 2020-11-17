using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;

namespace CacheableProperties.Generator
{
    [Generator]
    internal sealed class Generator : ISourceGenerator
    {
        private static (string name, SourceText text) GenerateFields(IPropertySymbol sourceSymbol)
            => ("", new Builder(sourceSymbol).ToSourceText());

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not Receiver receiver)
                return;
            var candidate = receiver.Candidate;
            var model = context.Compilation.GetSemanticModel(candidate.SyntaxTree);
            if (model.GetDeclaredSymbol(candidate) is IPropertySymbol propertySymbol)
            {
                var (name, text) = GenerateFields(propertySymbol);
                context.AddSource(name, text);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
            => context.RegisterForSyntaxNotifications(() => new Receiver());
    }
}
