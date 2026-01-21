using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using FeatureHighlighter.Parser;

namespace FeatureHighlighter.Classification
{
    /// <summary>
    /// Classifier that tokenizes Gherkin feature files and provides classification spans
    /// for syntax highlighting.
    /// </summary>
    internal class GherkinClassifier : IClassifier
    {
        private readonly IClassificationTypeRegistryService _classificationRegistry;
        private readonly ReqnrollGherkinParserWrapper _parser;
        private bool _inDocString = false;

        // Classification types
        private readonly IClassificationType _keywordType;
        private readonly IClassificationType _commentType;
        private readonly IClassificationType _tagType;
        private readonly IClassificationType _parameterType;
        private readonly IClassificationType _docStringType;
        private readonly IClassificationType _tableCellType;
        private readonly IClassificationType _tablePipeType;

#pragma warning disable 67
        /// <summary>
        /// Event raised when classification changes
        /// </summary>
        public event EventHandler<ClassificationChangedEventArgs>? ClassificationChanged;
#pragma warning restore 67

        public GherkinClassifier(IClassificationTypeRegistryService classificationRegistry)
        {
            _classificationRegistry = classificationRegistry;
            _parser = new ReqnrollGherkinParserWrapper();

            // Get classification types
            _keywordType = classificationRegistry.GetClassificationType("gherkin.keyword");
            _commentType = classificationRegistry.GetClassificationType("gherkin.comment");
            _tagType = classificationRegistry.GetClassificationType("gherkin.tag");
            _parameterType = classificationRegistry.GetClassificationType("gherkin.parameter");
            _docStringType = classificationRegistry.GetClassificationType("gherkin.docstring");
            _tableCellType = classificationRegistry.GetClassificationType("gherkin.table.cell");
            _tablePipeType = classificationRegistry.GetClassificationType("gherkin.table.pipe");
        }

        /// <summary>
        /// Returns classification spans for the given snapshot span
        /// </summary>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var classifications = new List<ClassificationSpan>();

            try
            {
                // Get the text of the span
                var snapshot = span.Snapshot;
                var startLine = snapshot.GetLineFromPosition(span.Start.Position);
                var endLine = snapshot.GetLineFromPosition(span.End.Position);

                // Process each line in the span
                for (int lineNumber = startLine.LineNumber; lineNumber <= endLine.LineNumber; lineNumber++)
                {
                    var line = snapshot.GetLineFromLineNumber(lineNumber);
                    var lineText = line.GetText();

                    // Check if we're entering or exiting a doc string block
                    if (_parser.IsDocStringLine(lineText))
                    {
                        _inDocString = !_inDocString;

                        // Classify the entire doc string delimiter line
                        var lineSpan = new SnapshotSpan(snapshot, line.Start.Position, line.Length);
                        classifications.Add(new ClassificationSpan(lineSpan, _docStringType));
                        continue;
                    }

                    // If we're inside a doc string, classify the entire line
                    if (_inDocString)
                    {
                        var lineSpan = new SnapshotSpan(snapshot, line.Start.Position, line.Length);
                        classifications.Add(new ClassificationSpan(lineSpan, _docStringType));
                        continue;
                    }

                    // Parse the line and get tokens
                    var tokens = _parser.ParseLine(lineText, line.Start.Position);

                    // Convert tokens to classification spans
                    foreach (var token in tokens)
                    {
                        if (token.Length > 0)
                        {
                            var tokenSpan = new SnapshotSpan(snapshot, token.StartPosition, token.Length);
                            var classificationType = GetClassificationTypeForToken(token.Type);

                            if (classificationType != null)
                            {
                                classifications.Add(new ClassificationSpan(tokenSpan, classificationType));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Silently handle parsing errors to prevent crashes
                // In a production extension, you might want to log these
            }

            return classifications;
        }

        /// <summary>
        /// Maps token types to classification types
        /// </summary>
        private IClassificationType? GetClassificationTypeForToken(GherkinTokenType tokenType)
        {
            return tokenType switch
            {
                GherkinTokenType.Keyword => _keywordType,
                GherkinTokenType.Comment => _commentType,
                GherkinTokenType.Tag => _tagType,
                GherkinTokenType.Parameter => _parameterType,
                GherkinTokenType.DocString => _docStringType,
                GherkinTokenType.TableCell => _tableCellType,
                GherkinTokenType.TablePipe => _tablePipeType,
                _ => null
            };
        }
    }
}
