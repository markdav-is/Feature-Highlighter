# Changelog

All notable changes to the Feature Highlighter extension will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Planned
- Light theme color optimization
- Additional Gherkin language support
- Performance improvements for very large files
- User-configurable color themes preset

## [1.0.0] - TBD (Initial Release)

### Added
- ✅ Syntax highlighting for all Gherkin elements
  - Keywords (Feature, Scenario, Given, When, Then, And, But, Background, Rule, Examples)
  - Comments (lines starting with #)
  - Tags (@tagname)
  - Parameters (<param>, {param}, "string", 'string')
  - Doc strings (triple quotes """)
  - Data tables (pipe-delimited cells)
- ✅ Multi-language keyword support
  - English (Feature, Scenario, Given, When, Then)
  - German (Funktionalität, Szenario, Angenommen, Wenn, Dann)
  - French (Fonctionnalité, Scénario, Soit, Quand, Alors)
  - Spanish (Característica, Escenario, Dado, Cuando, Entonces)
  - And more via Reqnroll Gherkin parser
- ✅ Reqnroll Gherkin parser integration for accurate tokenization
- ✅ Visual Studio 2022 support (17.0+)
- ✅ Optimized color scheme for VS Dark Theme
  - Keywords: Blue (#569CD6), Bold
  - Comments: Green (#57A64A), Italic
  - Tags: Light Blue (#9CDCFE)
  - Parameters: Light Green (#B8D7A3)
  - Doc Strings: Tan/Brown (#CE9178)
  - Table Cells: Yellow (#DCDCAA)
  - Table Pipes: Gray (#B0B0B0)
- ✅ User-customizable colors via Tools → Options → Fonts and Colors
- ✅ Lightweight and performant implementation
- ✅ MIT License
- ✅ Comprehensive documentation
  - README with installation and usage
  - CONTRIBUTING guide for developers
  - TESTING guide with detailed test procedures
  - VISUAL-GUIDE showing expected highlighting
  - PUBLISHING guide for marketplace distribution

### Technical Details
- Built with .NET Framework 4.8
- Uses Visual Studio SDK 17.0+
- MEF (Managed Extensibility Framework) components
- Classification-based syntax highlighting
- Reqnroll (v2.2.0) and Gherkin (v29.0.0) parser libraries

---

## Version History Template

When releasing new versions, use this template:

```markdown
## [X.Y.Z] - YYYY-MM-DD

### Added
- New features or capabilities

### Changed
- Changes to existing functionality

### Deprecated
- Features marked for removal in future versions

### Removed
- Removed features

### Fixed
- Bug fixes

### Security
- Security-related changes
```

---

## Semantic Versioning Guidelines

- **MAJOR version (X.0.0)** - Incompatible API changes or breaking changes
  - Example: Changing how colors are defined, removing features
- **MINOR version (1.X.0)** - New functionality in a backward-compatible manner
  - Example: Adding support for new Gherkin keywords, new color customization
- **PATCH version (1.0.X)** - Backward-compatible bug fixes
  - Example: Fixing highlighting bug, performance improvements

---

## Links

- [GitHub Repository](https://github.com/markdav-is/Feature-Highlighter)
- [Visual Studio Marketplace](https://marketplace.visualstudio.com) (link TBD after publishing)
- [Issue Tracker](https://github.com/markdav-is/Feature-Highlighter/issues)
