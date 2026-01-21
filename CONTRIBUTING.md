# Contributing to Feature Highlighter

Thank you for your interest in contributing to Feature Highlighter! This document provides guidelines and instructions for contributing to this project.

## Code of Conduct

Please be respectful and constructive in all interactions. We want to maintain a welcoming environment for everyone.

## How to Contribute

### Reporting Issues

If you find a bug or have a feature suggestion:

1. Check the [existing issues](https://github.com/markdav-is/Feature-Highlighter/issues) to avoid duplicates
2. Create a new issue with a clear title and description
3. Include:
   - Steps to reproduce (for bugs)
   - Expected behavior
   - Actual behavior
   - Visual Studio version
   - Sample .feature file (if applicable)
   - Screenshots (if helpful)

### Submitting Pull Requests

1. **Fork the repository** and create a new branch from `main`
2. **Make your changes** following our guidelines below
3. **Test thoroughly** in Visual Studio 2022
4. **Commit with clear messages** describing what and why
5. **Push to your fork** and submit a pull request

## Development Guidelines

### Project Scope

**Remember:** This extension is focused **only on syntax highlighting**. Do not add features like:
- Test generation or execution
- IntelliSense or autocomplete
- Step definition navigation
- Step binding detection
- Refactoring tools
- Code actions or quick fixes

If you want these features, contribute to SpecFlow or Reqnroll extensions instead.

### Code Style

- Use C# naming conventions (PascalCase for public members, _camelCase for private fields)
- Add XML documentation comments for public APIs
- Keep methods focused and reasonably sized
- Use nullable reference types appropriately
- Follow existing code patterns in the project

### Testing

Before submitting a PR, test your changes:

1. **Launch Experimental Instance**
   - Press F5 in Visual Studio 2022
   - This launches a separate VS instance with your extension loaded

2. **Test with Various Feature Files**
   - Test with `TestFiles/sample.feature`
   - Create feature files with edge cases
   - Test with different Gherkin languages (English, German, French, etc.)

3. **Verify All Syntax Elements**
   - Keywords (Feature, Scenario, Given, When, Then, etc.)
   - Comments (lines starting with #)
   - Tags (@tagname)
   - Parameters (<param>, {param}, "string", 'string')
   - Doc strings (""" content """)
   - Tables (| cell | cell |)

4. **Performance Testing**
   - Test with large feature files (1000+ lines)
   - Ensure no noticeable lag when scrolling or editing
   - Monitor CPU usage

### Multi-Language Support

When adding or modifying keyword detection:

- Support English, German, French, and Spanish at minimum
- Use the Reqnroll Gherkin parser's built-in language support
- Test with feature files in multiple languages
- Don't hardcode language-specific keywords unnecessarily

### Color Schemes

Default colors are optimized for VS Dark Theme:
- Keywords: #569CD6 (Blue, Bold)
- Comments: #57A64A (Green, Italic)
- Tags: #9CDCFE (Light Blue)
- Parameters: #B8D7A3 (Light Green)
- Doc Strings: #CE9178 (Tan/Brown)
- Table Cells: #DCDCAA (Yellow)
- Table Pipes: #B0B0B0 (Gray)

If proposing color changes:
- Test with both Dark and Light themes
- Ensure good contrast and readability
- Provide screenshots
- Consider colorblind users

## Project Structure

```
FeatureHighlighter/
├── Classification/
│   ├── GherkinContentTypeDefinition.cs    # Registers .feature content type
│   ├── GherkinClassificationDefinitions.cs # Defines token types
│   ├── GherkinFormatDefinitions.cs         # Defines colors/styles
│   ├── GherkinClassifier.cs                # Main classification logic
│   └── GherkinClassifierProvider.cs        # MEF provider
├── Parser/
│   └── ReqnrollGherkinParserWrapper.cs     # Wraps Gherkin parser
└── Resources/
    ├── icon.png                            # Extension icon
    └── preview.png                         # Preview screenshot
```

### Key Components

- **Content Type Definition**: Associates .feature files with "gherkin" content type
- **Classification Definitions**: Logical token categories (keyword, comment, etc.)
- **Format Definitions**: Visual styles for each token type
- **Classifier**: Analyzes text and assigns classifications
- **Parser Wrapper**: Uses Reqnroll parser to tokenize Gherkin syntax

## Building the Project

### Prerequisites

- Visual Studio 2022 (17.0 or higher)
- .NET Framework 4.8
- Visual Studio SDK installed

### Build Steps

```bash
# Clone your fork
git clone https://github.com/YOUR-USERNAME/Feature-Highlighter.git
cd Feature-Highlighter

# Open in Visual Studio
start FeatureHighlighter.sln

# Or build from command line
msbuild FeatureHighlighter.sln /p:Configuration=Debug
```

### Debugging

1. Set `FeatureHighlighter` as the startup project
2. Press F5 to launch Experimental Instance
3. Open a .feature file in the Experimental Instance
4. Set breakpoints in your code to debug

## Pull Request Checklist

Before submitting your PR, ensure:

- [ ] Code builds without errors or warnings
- [ ] Extension loads in VS 2022 Experimental Instance
- [ ] Syntax highlighting works for all Gherkin elements
- [ ] Tested with multiple language variants
- [ ] Tested with large files (performance)
- [ ] No breaking changes to existing functionality
- [ ] Code follows project style guidelines
- [ ] XML documentation added for new public APIs
- [ ] Commits have clear, descriptive messages
- [ ] PR description explains the change and why it's needed

## Questions?

If you have questions about contributing:
- Open a [Discussion](https://github.com/markdav-is/Feature-Highlighter/discussions)
- Comment on a relevant issue
- Review existing PRs to see how others have contributed

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to Feature Highlighter! 🎉
