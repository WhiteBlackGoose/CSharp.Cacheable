using Microsoft.CodeAnalysis;
using System;

namespace CacheableProperties.Generator
{
    [Generator]
    internal sealed class Generator : ISourceGenerator
    {
        private static (ImmutableArray<Diagnostic> diagnostics, string? name, SourceText? text) GenerateMapping(
            ITypeSymbol sourceType, AttributeData attributeData)
        {
            var information = new MappingInformation(sourceType, attributeData);

            if (!information.Diagnostics.Any(_ => _.Severity == DiagnosticSeverity.Error))
            {
                var text = new MappingBuilder(information).Text;
                return (information.Diagnostics, $"{sourceType.Name}_To_{information.DestinationType.Name}_Map.g.cs", text);
            }

            return (ImmutableArray<Diagnostic>.Empty, null, null);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not Receiver receiver)
                return;
            var candidate = receiver.Candidate;
            var model = context.Compilation.GetSemanticModel(candidate.SyntaxTree);
            if (model.GetDeclaredSymbol(candidate) is IPropertySymbol propertySymbol)
            {
                
            }
        }

        public void Initialize(GeneratorInitializationContext context)
            => context.RegisterForSyntaxNotifications(() => new Receiver());
    }
}
