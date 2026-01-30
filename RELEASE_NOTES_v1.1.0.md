# ?? Feature Highlighter v1.1.0

**Lightweight Gherkin/Cucumber syntax highlighting for Visual Studio 2022+**

## ? What's New in v1.1.0

### Improvements
- **? Reduced Dependencies**: Removed unused Gherkin and Reqnroll package dependencies
- **?? Smaller Package Size**: Extension is now lighter and faster to install (~125 KB)
- **? Custom Parser**: Fully self-contained implementation with no external parsing libraries
- **?? Better Performance**: Fewer dependencies mean faster loading and reduced memory footprint

## ?? Features

- **?? Complete Syntax Highlighting**
  - Keywords (`Feature`, `Scenario`, `Given`, `When`, `Then`, `And`, `But`)
  - Comments (`#`)
  - Tags (`@smoke`, `@regression`)
  - Parameters (`<placeholder>`, `"text"`)
  - Data tables
  - Doc strings (`"""`)

- **?? Multi-Language Support**
  - Supports Gherkin in all languages (English, French, German, Spanish, etc.)
  - Custom parser with accurate tokenization

- **? Lightweight & Fast**
  - Minimal memory footprint
  - No lag or performance impact
  - Clean integration with Visual Studio's editor

- **?? Visual Studio 2022+ Support**
  - Compatible with VS 2022 and future versions (Community, Professional, Enterprise)
  - Works with both light and dark themes
  - Native MEF-based extension

## ?? Requirements

- Visual Studio 2022 or later (version 17.0+)
- .NET Framework 4.7.2

## ?? Installation

1. Download `FeatureHighlighter.vsix` from this release
2. Double-click to install
3. Restart Visual Studio
4. Open any `.feature` file and enjoy syntax highlighting!

## ?? Known Issues

None reported yet!

## ?? Feedback

Found a bug or have a suggestion? [Open an issue](https://github.com/markdav-is/Feature-Highlighter/issues)!

## ?? What's Included

- `FeatureHighlighter.vsix` - The Visual Studio extension installer

---

**Full Changelog**: https://github.com/markdav-is/Feature-Highlighter/compare/v1.0.0...v1.1.0
