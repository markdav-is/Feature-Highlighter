using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Gherkin;
using Gherkin.Ast;

namespace FeatureHighlighter.Parser
{
    /// <summary>
    /// Token types that can be identified by the Gherkin parser
    /// </summary>
    internal enum GherkinTokenType
    {
        None,
        Keyword,
        Comment,
        Tag,
        Parameter,
        DocString,
        TableCell,
        TablePipe
    }

    /// <summary>
    /// Represents a token identified by the parser with its position and type
    /// </summary>
    internal class GherkinToken
    {
        public int StartPosition { get; set; }
        public int Length { get; set; }
        public GherkinTokenType Type { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    /// <summary>
    /// Wrapper around the Gherkin parser for tokenizing feature file content.
    /// This parser handles multiple languages automatically.
    /// </summary>
    internal class ReqnrollGherkinParserWrapper
    {
        private static readonly HashSet<string> GherkinKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Feature", "Funktionalität", "Fonctionnalité", "Característica", // Feature
            "Background", "Grundlage", "Contexte", "Antecedentes", // Background
            "Scenario", "Szenario", "Scénario", "Escenario", // Scenario
            "Scenario Outline", "Szenariogrundriss", "Plan du scénario", "Esquema del escenario", // Scenario Outline
            "Rule", "Regel", "Règle", "Regla", // Rule
            "Example", "Beispiel", "Exemple", "Ejemplo", // Example
            "Examples", "Beispiele", "Exemples", "Ejemplos", // Examples
            "Given", "Angenommen", "Soit", "Dado", "Étant donné", // Given
            "When", "Wenn", "Quand", "Cuando", "Lorsque", // When
            "Then", "Dann", "Alors", "Entonces", // Then
            "And", "Und", "Et", "Y", // And
            "But", "Aber", "Mais", "Pero" // But
        };

        /// <summary>
        /// Parses a line of text and returns the tokens found
        /// </summary>
        public List<GherkinToken> ParseLine(string lineText, int lineStartPosition)
        {
            var tokens = new List<GherkinToken>();

            if (string.IsNullOrWhiteSpace(lineText))
            {
                return tokens;
            }

            string trimmedLine = lineText.TrimStart();
            int leadingWhitespace = lineText.Length - trimmedLine.Length;

            // Check for comment (entire line)
            if (trimmedLine.StartsWith("#"))
            {
                tokens.Add(new GherkinToken
                {
                    StartPosition = lineStartPosition,
                    Length = lineText.Length,
                    Type = GherkinTokenType.Comment,
                    Text = lineText
                });
                return tokens;
            }

            // Check for tags
            if (trimmedLine.StartsWith("@"))
            {
                ParseTags(lineText, lineStartPosition, tokens);
                return tokens;
            }

            // Check for table row
            if (trimmedLine.StartsWith("|"))
            {
                ParseTableRow(lineText, lineStartPosition, tokens);
                return tokens;
            }

            // Check for doc string delimiter
            if (trimmedLine.StartsWith("\"\"\"") || trimmedLine.StartsWith("```"))
            {
                tokens.Add(new GherkinToken
                {
                    StartPosition = lineStartPosition,
                    Length = lineText.Length,
                    Type = GherkinTokenType.DocString,
                    Text = lineText
                });
                return tokens;
            }

            // Check for keywords at the start of the line
            ParseKeywordsAndParameters(lineText, lineStartPosition, tokens);

            return tokens;
        }

        /// <summary>
        /// Parses tags from a line (e.g., @tag1 @tag2)
        /// </summary>
        private void ParseTags(string lineText, int lineStartPosition, List<GherkinToken> tokens)
        {
            int currentPos = 0;
            while (currentPos < lineText.Length)
            {
                // Skip whitespace
                while (currentPos < lineText.Length && char.IsWhiteSpace(lineText[currentPos]))
                {
                    currentPos++;
                }

                if (currentPos >= lineText.Length)
                    break;

                // Found a tag
                if (lineText[currentPos] == '@')
                {
                    int tagStart = currentPos;
                    currentPos++; // skip @

                    // Continue until whitespace or end
                    while (currentPos < lineText.Length && !char.IsWhiteSpace(lineText[currentPos]))
                    {
                        currentPos++;
                    }

                    int tagLength = currentPos - tagStart;
                    tokens.Add(new GherkinToken
                    {
                        StartPosition = lineStartPosition + tagStart,
                        Length = tagLength,
                        Type = GherkinTokenType.Tag,
                        Text = lineText.Substring(tagStart, tagLength)
                    });
                }
                else
                {
                    currentPos++;
                }
            }
        }

        /// <summary>
        /// Parses a table row (e.g., | cell1 | cell2 |)
        /// </summary>
        private void ParseTableRow(string lineText, int lineStartPosition, List<GherkinToken> tokens)
        {
            int currentPos = 0;
            bool inCell = false;
            int cellStart = 0;

            while (currentPos < lineText.Length)
            {
                if (lineText[currentPos] == '|')
                {
                    // Add pipe token
                    tokens.Add(new GherkinToken
                    {
                        StartPosition = lineStartPosition + currentPos,
                        Length = 1,
                        Type = GherkinTokenType.TablePipe,
                        Text = "|"
                    });

                    // If we were in a cell, close it
                    if (inCell)
                    {
                        int cellEnd = currentPos;
                        int cellLength = cellEnd - cellStart;
                        if (cellLength > 0)
                        {
                            tokens.Add(new GherkinToken
                            {
                                StartPosition = lineStartPosition + cellStart,
                                Length = cellLength,
                                Type = GherkinTokenType.TableCell,
                                Text = lineText.Substring(cellStart, cellLength)
                            });
                        }
                        inCell = false;
                    }

                    currentPos++;

                    // Start new cell after pipe (skip leading whitespace)
                    while (currentPos < lineText.Length && lineText[currentPos] == ' ')
                    {
                        currentPos++;
                    }

                    cellStart = currentPos;
                    inCell = true;
                }
                else
                {
                    currentPos++;
                }
            }
        }

        /// <summary>
        /// Parses keywords and parameters from a line
        /// </summary>
        private void ParseKeywordsAndParameters(string lineText, int lineStartPosition, List<GherkinToken> tokens)
        {
            // Check if line starts with a keyword
            string trimmedLine = lineText.TrimStart();
            int leadingWhitespace = lineText.Length - trimmedLine.Length;

            foreach (var keyword in GherkinKeywords)
            {
                if (trimmedLine.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    // Check if it's followed by whitespace or colon (to avoid partial matches)
                    int keywordEndPos = keyword.Length;
                    if (keywordEndPos >= trimmedLine.Length ||
                        char.IsWhiteSpace(trimmedLine[keywordEndPos]) ||
                        trimmedLine[keywordEndPos] == ':')
                    {
                        tokens.Add(new GherkinToken
                        {
                            StartPosition = lineStartPosition + leadingWhitespace,
                            Length = keyword.Length,
                            Type = GherkinTokenType.Keyword,
                            Text = keyword
                        });

                        // Parse the rest of the line for parameters
                        string remainingText = trimmedLine.Substring(keyword.Length);
                        int remainingStart = lineStartPosition + leadingWhitespace + keyword.Length;
                        ParseParameters(remainingText, remainingStart, tokens);

                        return;
                    }
                }
            }

            // If no keyword found, still check for parameters in the entire line
            ParseParameters(lineText, lineStartPosition, tokens);
        }

        /// <summary>
        /// Parses parameters from text (e.g., <param>, {param}, "string", 'string')
        /// </summary>
        private void ParseParameters(string text, int textStartPosition, List<GherkinToken> tokens)
        {
            int currentPos = 0;

            while (currentPos < text.Length)
            {
                char c = text[currentPos];

                // Check for <parameter>
                if (c == '<')
                {
                    int paramStart = currentPos;
                    currentPos++;
                    while (currentPos < text.Length && text[currentPos] != '>')
                    {
                        currentPos++;
                    }
                    if (currentPos < text.Length) // found closing >
                    {
                        currentPos++; // include the >
                        int paramLength = currentPos - paramStart;
                        tokens.Add(new GherkinToken
                        {
                            StartPosition = textStartPosition + paramStart,
                            Length = paramLength,
                            Type = GherkinTokenType.Parameter,
                            Text = text.Substring(paramStart, paramLength)
                        });
                    }
                }
                // Check for {parameter}
                else if (c == '{')
                {
                    int paramStart = currentPos;
                    currentPos++;
                    while (currentPos < text.Length && text[currentPos] != '}')
                    {
                        currentPos++;
                    }
                    if (currentPos < text.Length) // found closing }
                    {
                        currentPos++; // include the }
                        int paramLength = currentPos - paramStart;
                        tokens.Add(new GherkinToken
                        {
                            StartPosition = textStartPosition + paramStart,
                            Length = paramLength,
                            Type = GherkinTokenType.Parameter,
                            Text = text.Substring(paramStart, paramLength)
                        });
                    }
                }
                // Check for "string"
                else if (c == '"')
                {
                    int paramStart = currentPos;
                    currentPos++;
                    while (currentPos < text.Length && text[currentPos] != '"')
                    {
                        // Handle escaped quotes
                        if (text[currentPos] == '\\' && currentPos + 1 < text.Length)
                        {
                            currentPos += 2;
                        }
                        else
                        {
                            currentPos++;
                        }
                    }
                    if (currentPos < text.Length) // found closing "
                    {
                        currentPos++; // include the "
                        int paramLength = currentPos - paramStart;
                        tokens.Add(new GherkinToken
                        {
                            StartPosition = textStartPosition + paramStart,
                            Length = paramLength,
                            Type = GherkinTokenType.Parameter,
                            Text = text.Substring(paramStart, paramLength)
                        });
                    }
                }
                // Check for 'string'
                else if (c == '\'')
                {
                    int paramStart = currentPos;
                    currentPos++;
                    while (currentPos < text.Length && text[currentPos] != '\'')
                    {
                        // Handle escaped quotes
                        if (text[currentPos] == '\\' && currentPos + 1 < text.Length)
                        {
                            currentPos += 2;
                        }
                        else
                        {
                            currentPos++;
                        }
                    }
                    if (currentPos < text.Length) // found closing '
                    {
                        currentPos++; // include the '
                        int paramLength = currentPos - paramStart;
                        tokens.Add(new GherkinToken
                        {
                            StartPosition = textStartPosition + paramStart,
                            Length = paramLength,
                            Type = GherkinTokenType.Parameter,
                            Text = text.Substring(paramStart, paramLength)
                        });
                    }
                }
                else
                {
                    currentPos++;
                }
            }
        }

        /// <summary>
        /// Checks if a line is within a doc string block
        /// </summary>
        public bool IsDocStringLine(string lineText)
        {
            string trimmedLine = lineText.TrimStart();
            return trimmedLine.StartsWith("\"\"\"") || trimmedLine.StartsWith("```");
        }
    }
}
