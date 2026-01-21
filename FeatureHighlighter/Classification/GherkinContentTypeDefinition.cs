using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace FeatureHighlighter.Classification
{
    /// <summary>
    /// Defines the "gherkin" content type and associates it with .feature file extensions.
    /// </summary>
    internal static class GherkinContentTypeDefinition
    {
        /// <summary>
        /// Exports the "gherkin" content type.
        /// </summary>
        [Export]
        [Name("gherkin")]
        [BaseDefinition("text")]
        public static ContentTypeDefinition? GherkinContentType { get; set; }

        /// <summary>
        /// Associates the .feature file extension with the gherkin content type.
        /// </summary>
        [Export]
        [FileExtension(".feature")]
        [ContentType("gherkin")]
        public static FileExtensionToContentTypeDefinition? FeatureFileExtension { get; set; }
    }
}
