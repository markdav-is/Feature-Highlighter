using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace FeatureHighlighter.Classification
{
    /// <summary>
    /// Defines classification types for Gherkin syntax elements.
    /// These are the logical categories that the classifier will use to tag text spans.
    /// </summary>
    internal static class GherkinClassificationDefinitions
    {
        /// <summary>
        /// Classification for Gherkin keywords (Feature, Scenario, Given, When, Then, etc.)
        /// </summary>
        [Export]
        [Name("gherkin.keyword")]
        [BaseDefinition("keyword")]
        public static ClassificationTypeDefinition GherkinKeyword { get; set; }

        /// <summary>
        /// Classification for Gherkin comments (lines starting with #)
        /// </summary>
        [Export]
        [Name("gherkin.comment")]
        [BaseDefinition("comment")]
        public static ClassificationTypeDefinition GherkinComment { get; set; }

        /// <summary>
        /// Classification for Gherkin tags (@tagname)
        /// </summary>
        [Export]
        [Name("gherkin.tag")]
        [BaseDefinition("identifier")]
        public static ClassificationTypeDefinition GherkinTag { get; set; }

        /// <summary>
        /// Classification for Gherkin step parameters (<param>, {param}, "string")
        /// </summary>
        [Export]
        [Name("gherkin.parameter")]
        [BaseDefinition("string")]
        public static ClassificationTypeDefinition GherkinParameter { get; set; }

        /// <summary>
        /// Classification for Gherkin doc strings (triple quotes)
        /// </summary>
        [Export]
        [Name("gherkin.docstring")]
        [BaseDefinition("string")]
        public static ClassificationTypeDefinition GherkinDocString { get; set; }

        /// <summary>
        /// Classification for Gherkin table cell content
        /// </summary>
        [Export]
        [Name("gherkin.table.cell")]
        [BaseDefinition("text")]
        public static ClassificationTypeDefinition GherkinTableCell { get; set; }

        /// <summary>
        /// Classification for Gherkin table pipe delimiters
        /// </summary>
        [Export]
        [Name("gherkin.table.pipe")]
        [BaseDefinition("operator")]
        public static ClassificationTypeDefinition GherkinTablePipe { get; set; }
    }
}
