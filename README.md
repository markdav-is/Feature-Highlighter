# Feature Highlighter

A lightweight Visual Studio extension that provides **syntax highlighting only** for Gherkin/Cucumber `.feature` files.

## What It Does

Feature Highlighter brings beautiful, accurate syntax highlighting to your BDD feature files using the [Reqnroll](https://reqnroll.net/) Gherkin parser. It supports multiple languages automatically (English, German, French, Spanish, and more).

**This extension focuses on one thing:** making your feature files easier to read with proper syntax coloring.

## What It Does NOT Do

This extension is intentionally minimal and does **NOT** include:

- ❌ Test generation or execution
- ❌ IntelliSense or autocomplete
- ❌ Step definition navigation
- ❌ Step binding detection
- ❌ Refactoring tools
- ❌ Code actions or quick fixes

If you need these features, consider using the full [SpecFlow](https://specflow.org/) or [Reqnroll](https://reqnroll.net/) extensions instead.

## Features

### Syntax Elements Highlighted

- **Keywords** - `Feature`, `Scenario`, `Given`, `When`, `Then`, `And`, `But`, `Background`, `Rule`, `Examples` (Blue, Bold)
- **Comments** - Lines starting with `#` (Green, Italic)
- **Tags** - `@tagname` (Light Blue/Cyan)
- **Parameters** - `<parameter>`, `{parameter}`, `"string"`, `'string'` (Light Green)
- **Doc Strings** - Triple quotes `"""` content `"""` (Tan/Brown)
- **Tables** - Pipe-delimited data tables with cell highlighting (Yellow-ish)

### Multi-Language Support

Thanks to the Reqnroll Gherkin parser, keywords are automatically recognized in multiple languages:

- 🇬🇧 English: `Feature`, `Scenario`, `Given`, `When`, `Then`
- 🇩🇪 German: `Funktionalität`, `Szenario`, `Angenommen`, `Wenn`, `Dann`
- 🇫🇷 French: `Fonctionnalité`, `Scénario`, `Soit`, `Quand`, `Alors`
- 🇪🇸 Spanish: `Característica`, `Escenario`, `Dado`, `Cuando`, `Entonces`
- And more!

## Installation

### From VSIX File

1. Download the latest `.vsix` file from the [Releases](https://github.com/markdav-is/Feature-Highlighter/releases) page
2. Double-click the `.vsix` file
3. Follow the Visual Studio installer prompts
4. Restart Visual Studio

### From Visual Studio Marketplace

1. Open Visual Studio 2022
2. Go to **Extensions → Manage Extensions**
3. Search for "Feature Highlighter"
4. Click **Download** and restart Visual Studio

## Requirements

- Visual Studio 2022 (version 17.0 or higher)
- .NET Framework 4.8

## Usage

Just open any `.feature` file in Visual Studio 2022, and syntax highlighting will be automatically applied!

### Customizing Colors

You can customize the colors used for highlighting:

1. Go to **Tools → Options → Environment → Fonts and Colors**
2. In the "Display items" list, look for entries starting with "Gherkin":
   - Gherkin Keyword
   - Gherkin Comment
   - Gherkin Tag
   - Gherkin Parameter
   - Gherkin Doc String
   - Gherkin Table Cell
   - Gherkin Table Pipe
3. Change the colors to your preference
4. Click **OK** to apply

## Example

Here's what a highlighted feature file looks like:

```gherkin
# This is a comment
@smoke @regression
Feature: User Authentication
  As a user
  I want to log in to the system
  So that I can access my account

  Background:
    Given the application is running

  Scenario: Successful login with valid credentials
    Given I am on the login page
    When I enter username "john.doe" and password "secret123"
    And I click the login button
    Then I should see the dashboard
    And I should see a welcome message "Welcome, John!"

  Scenario Outline: Login with different credentials
    Given I am on the login page
    When I enter username "<username>" and password "<password>"
    Then I should see <result>

    Examples:
      | username  | password  | result           |
      | john.doe  | secret123 | dashboard        |
      | jane.doe  | pass456   | dashboard        |
      | invalid   | wrong     | error message    |

  Rule: Password security

    Scenario: Password requirements
      Given I am creating a new account
      When I enter a password with {min_length} characters
      Then the system should accept the password
      """
      Passwords must be at least 8 characters long
      and contain at least one number and one special character
      """
```

## Building from Source

### Prerequisites

- Visual Studio 2022 with the following workloads:
  - .NET desktop development
  - Visual Studio extension development

### Build Steps

```bash
# Clone the repository
git clone https://github.com/markdav-is/Feature-Highlighter.git
cd Feature-Highlighter

# Open in Visual Studio 2022
start FeatureHighlighter.sln

# Or build from command line
msbuild FeatureHighlighter.sln /p:Configuration=Release
```

### Testing the Extension

1. Open the solution in Visual Studio 2022
2. Press **F5** to launch the Experimental Instance
3. In the Experimental Instance, open a `.feature` file
4. Verify that syntax highlighting is applied correctly

### Creating a VSIX Package

1. Build the solution in **Release** configuration
2. The `.vsix` file will be in `FeatureHighlighter/bin/Release/FeatureHighlighter.vsix`

## Architecture

The extension uses the Visual Studio Editor extensibility model:

- **Content Type Definition** - Registers `.feature` files as "gherkin" content type
- **Classification Definitions** - Defines logical token types (keyword, comment, tag, etc.)
- **Format Definitions** - Defines visual styles (colors, fonts) for each token type
- **Classifier** - Analyzes text and assigns classification types to text spans
- **Parser Wrapper** - Uses Reqnroll's Gherkin parser for accurate tokenization

## Credits and Acknowledgments

This extension uses the [Reqnroll](https://reqnroll.net/) Gherkin parser (BSD-3-Clause license) for robust, standards-compliant parsing of Gherkin syntax.

Special thanks to:
- The Reqnroll team for creating an excellent open-source BDD framework
- The SpecFlow team for pioneering .NET BDD tooling
- The Cucumber community for the Gherkin language specification

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

The Reqnroll library used by this extension is licensed under the BSD-3-Clause license.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

### Contribution Guidelines

1. Keep the extension focused on syntax highlighting only
2. Follow the existing code style
3. Test with multiple language variants (English, German, French, etc.)
4. Ensure performance is good for large files
5. Update documentation as needed

## Support

- **Issues**: [GitHub Issues](https://github.com/markdav-is/Feature-Highlighter/issues)
- **Discussions**: [GitHub Discussions](https://github.com/markdav-is/Feature-Highlighter/discussions)

## Changelog

### Version 1.0.0 (Initial Release)

- ✅ Syntax highlighting for all Gherkin elements
- ✅ Multi-language keyword support
- ✅ Support for parameters, tags, comments, doc strings, and tables
- ✅ Optimized for Visual Studio 2022 Dark Theme
- ✅ Lightweight and performant

## Roadmap

Potential future enhancements (while keeping the extension focused on highlighting):

- Light theme color optimization
- Additional language support
- Performance improvements for very large files
- User-configurable color themes

---

**Made with ❤️ for the BDD community**
