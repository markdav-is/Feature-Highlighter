using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace FeatureHighlighter.Classification
{
    /// <summary>
    /// Provider for the Gherkin classifier. This is a MEF component that creates
    /// classifier instances for Gherkin content type text buffers.
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("gherkin")]
    internal class GherkinClassifierProvider : IClassifierProvider
    {
        /// <summary>
        /// Import the classification registry to be used for creating classification types.
        /// </summary>
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry { get; set; } = null!;

        /// <summary>
        /// Creates a classifier for the given text buffer.
        /// </summary>
        /// <param name="buffer">The text buffer to classify</param>
        /// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.</returns>
        public IClassifier? GetClassifier(ITextBuffer buffer)
        {
            // Return a new classifier instance for this buffer
            // We could also cache classifiers per buffer if needed
            return buffer.Properties.GetOrCreateSingletonProperty(() =>
                new GherkinClassifier(ClassificationRegistry));
        }
    }
}
