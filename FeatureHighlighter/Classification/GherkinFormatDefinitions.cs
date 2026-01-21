using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace FeatureHighlighter.Classification
{
    /// <summary>
    /// Defines the visual formatting (colors, fonts, etc.) for Gherkin classification types.
    /// These colors are optimized for the Visual Studio Dark Theme.
    /// </summary>
    internal static class GherkinFormatDefinitions
    {
        /// <summary>
        /// Format for Gherkin keywords - Blue and Bold
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.keyword")]
        [Name("gherkin.keyword")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinKeywordFormat : ClassificationFormatDefinition
        {
            public GherkinKeywordFormat()
            {
                DisplayName = "Gherkin Keyword";
                ForegroundColor = Color.FromRgb(0x56, 0x9C, 0xD6); // VS Blue
                IsBold = true;
            }
        }

        /// <summary>
        /// Format for Gherkin comments - Green and Italic
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.comment")]
        [Name("gherkin.comment")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinCommentFormat : ClassificationFormatDefinition
        {
            public GherkinCommentFormat()
            {
                DisplayName = "Gherkin Comment";
                ForegroundColor = Color.FromRgb(0x57, 0xA6, 0x4A); // VS Green
                IsItalic = true;
            }
        }

        /// <summary>
        /// Format for Gherkin tags - Light Blue/Cyan
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.tag")]
        [Name("gherkin.tag")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinTagFormat : ClassificationFormatDefinition
        {
            public GherkinTagFormat()
            {
                DisplayName = "Gherkin Tag";
                ForegroundColor = Color.FromRgb(0x9C, 0xDC, 0xFE); // VS Light Blue
            }
        }

        /// <summary>
        /// Format for Gherkin parameters - Light Green
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.parameter")]
        [Name("gherkin.parameter")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinParameterFormat : ClassificationFormatDefinition
        {
            public GherkinParameterFormat()
            {
                DisplayName = "Gherkin Parameter";
                ForegroundColor = Color.FromRgb(0xB8, 0xD7, 0xA3); // VS Light Green
            }
        }

        /// <summary>
        /// Format for Gherkin doc strings - Tan/Brown (VS String Color)
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.docstring")]
        [Name("gherkin.docstring")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinDocStringFormat : ClassificationFormatDefinition
        {
            public GherkinDocStringFormat()
            {
                DisplayName = "Gherkin Doc String";
                ForegroundColor = Color.FromRgb(0xCE, 0x91, 0x78); // VS String Color
            }
        }

        /// <summary>
        /// Format for Gherkin table cells - Yellow-ish
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.table.cell")]
        [Name("gherkin.table.cell")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinTableCellFormat : ClassificationFormatDefinition
        {
            public GherkinTableCellFormat()
            {
                DisplayName = "Gherkin Table Cell";
                ForegroundColor = Color.FromRgb(0xDC, 0xDC, 0xAA); // VS Yellow
            }
        }

        /// <summary>
        /// Format for Gherkin table pipes - Lighter gray
        /// </summary>
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = "gherkin.table.pipe")]
        [Name("gherkin.table.pipe")]
        [UserVisible(true)]
        [Order(Before = Priority.Default)]
        internal sealed class GherkinTablePipeFormat : ClassificationFormatDefinition
        {
            public GherkinTablePipeFormat()
            {
                DisplayName = "Gherkin Table Pipe";
                ForegroundColor = Color.FromRgb(0xB0, 0xB0, 0xB0); // Light Gray
            }
        }
    }
}
