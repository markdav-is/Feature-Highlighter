# Testing Guide for Feature Highlighter

This guide walks you through testing the Feature Highlighter extension during development.

## Prerequisites

Before you can test the extension, ensure you have:

- ✅ **Visual Studio 2022** (Community, Professional, or Enterprise)
- ✅ **Visual Studio Extension Development workload** installed
  - Go to: Tools → Get Tools and Features
  - Check: "Visual Studio extension development"
  - Install if not already installed

## Quick Start Testing (5 minutes)

### Step 1: Open the Solution

```bash
# Navigate to the project directory
cd /path/to/Feature-Highlighter

# Open the solution in Visual Studio 2022
# On Windows:
start FeatureHighlighter.sln

# Or launch Visual Studio and open FeatureHighlighter.sln
```

### Step 2: Build the Project

1. In Visual Studio, open **FeatureHighlighter.sln**
2. Go to **Build → Build Solution** (or press `Ctrl+Shift+B`)
3. Check the **Output** window for any errors
4. You should see: `Build succeeded`

**If you get build errors:**
- Ensure .NET Framework 4.8 is installed
- Restore NuGet packages: Right-click solution → Restore NuGet Packages
- Clean and rebuild: Build → Clean Solution, then Build → Build Solution

### Step 3: Launch Experimental Instance

1. In Visual Studio, press **F5** (or click Debug → Start Debugging)
2. This launches a new Visual Studio window titled: **"Microsoft Visual Studio (Experimental Instance)"**
3. Wait for it to fully load (may take 30-60 seconds first time)

**What is the Experimental Instance?**
- A separate VS environment for testing extensions
- Has its own settings and installed extensions
- Won't affect your main Visual Studio installation
- Safe sandbox for development

### Step 4: Open a Feature File

In the **Experimental Instance** window:

1. Go to **File → Open → File** (or press `Ctrl+O`)
2. Navigate to: `Feature-Highlighter/TestFiles/sample.feature`
3. Open the file

**Expected Result:**
- You should see syntax highlighting applied!
- Keywords (Feature, Scenario, Given, When, Then) should be **blue and bold**
- Comments (#) should be **green and italic**
- Tags (@smoke) should be **light blue/cyan**
- Parameters (<param>, "string") should be **light green**
- Tables should have **yellow cells** and **gray pipes**

### Step 5: Test Interactively

In the Experimental Instance, try these tests:

#### Test 1: Create a New Feature File

1. **File → New → File**
2. Save as: `test.feature`
3. Type some Gherkin:

```gherkin
Feature: Quick Test
  Scenario: Testing highlighting
    Given I test the extension
    When I type some keywords
    Then they should be highlighted
```

**Expected:** Keywords should highlight as you type

#### Test 2: Test Comments

Add a comment:
```gherkin
# This is a comment
Feature: Quick Test
```

**Expected:** Comment line should be green and italic

#### Test 3: Test Tags

Add tags:
```gherkin
@smoke @regression
Feature: Quick Test
```

**Expected:** Tags should be light blue/cyan

#### Test 4: Test Parameters

Add parameters:
```gherkin
Given I enter username "john.doe"
And I see <parameter> and {another}
```

**Expected:** All parameters should be light green

#### Test 5: Test Tables

Add a table:
```gherkin
Examples:
  | username | password |
  | john     | secret   |
```

**Expected:** Cells should be yellow, pipes should be gray

#### Test 6: Test Doc Strings

Add a doc string:
```gherkin
Then I see the message
  """
  This is a doc string
  with multiple lines
  """
```

**Expected:** All doc string content should be tan/brown

### Step 6: Stop Debugging

When done testing:
- Close the Experimental Instance window
- Or in the main VS window: Debug → Stop Debugging (Shift+F5)

## Detailed Testing Checklist

Use this checklist to thoroughly test the extension:

### Basic Functionality

- [ ] Extension loads without errors in Experimental Instance
- [ ] .feature files are recognized and opened as text files
- [ ] Syntax highlighting is applied automatically when opening .feature files
- [ ] No performance issues (lag) when scrolling through files

### Syntax Elements

Test each element in `TestFiles/sample.feature`:

- [ ] **Feature keyword** - Blue, bold
- [ ] **Background keyword** - Blue, bold
- [ ] **Scenario keyword** - Blue, bold
- [ ] **Scenario Outline keyword** - Blue, bold
- [ ] **Rule keyword** - Blue, bold
- [ ] **Examples keyword** - Blue, bold
- [ ] **Given/When/Then/And/But** - Blue, bold
- [ ] **Comments (#)** - Green, italic
- [ ] **Tags (@tag)** - Light blue/cyan
- [ ] **Angle bracket params (<param>)** - Light green
- [ ] **Curly brace params ({param})** - Light green
- [ ] **Double quoted strings ("text")** - Light green
- [ ] **Single quoted strings ('text')** - Light green
- [ ] **Doc strings (""")** - Tan/brown for entire block
- [ ] **Table cells (| cell |)** - Yellow
- [ ] **Table pipes (|)** - Gray

### Edge Cases

- [ ] Empty lines don't cause errors
- [ ] Very long lines don't cause issues
- [ ] Nested quotes handled correctly: "text with 'quotes'"
- [ ] Escaped quotes handled: "text with \" quote"
- [ ] Mixed case keywords work: "FEATURE", "feature", "Feature"
- [ ] Keywords at end of line work: "Given something:"

### Multi-Language Support

Create test files for different languages:

**German (german.feature):**
```gherkin
# Deutsche Version
Funktionalität: Benutzer-Authentifizierung
  Szenario: Erfolgreiche Anmeldung
    Angenommen ich bin auf der Login-Seite
    Wenn ich meine Daten eingebe
    Dann sollte ich eingeloggt sein
```

**French (french.feature):**
```gherkin
# Version française
Fonctionnalité: Authentification utilisateur
  Scénario: Connexion réussie
    Soit je suis sur la page de connexion
    Quand je saisis mes identifiants
    Alors je devrais être connecté
```

**Spanish (spanish.feature):**
```gherkin
# Versión española
Característica: Autenticación de usuario
  Escenario: Inicio de sesión exitoso
    Dado que estoy en la página de inicio de sesión
    Cuando ingreso mis credenciales
    Entonces debería estar conectado
```

- [ ] German keywords highlighted correctly
- [ ] French keywords highlighted correctly
- [ ] Spanish keywords highlighted correctly

### Performance Testing

Test with large files:

1. Create a feature file with 1000+ lines (copy/paste scenarios)
2. Open in Experimental Instance
3. Scroll through the file
4. Edit content

- [ ] No noticeable lag when scrolling
- [ ] No lag when typing
- [ ] CPU usage remains reasonable
- [ ] Memory usage is acceptable

### Color Customization

Test that users can customize colors:

1. In Experimental Instance: **Tools → Options**
2. Navigate to: **Environment → Fonts and Colors**
3. In "Display items", find "Gherkin Keyword"
4. Change the color
5. Click OK
6. Verify the color changed in your .feature file

- [ ] All Gherkin classification types appear in Fonts and Colors
- [ ] Color changes are applied immediately
- [ ] Changes persist after restarting Experimental Instance

## Debugging Tips

### Setting Breakpoints

To debug the extension code:

1. In the main VS window (not Experimental), open a C# file
2. Set a breakpoint in `GherkinClassifier.cs` → `GetClassificationSpans` method
3. Press F5 to launch Experimental Instance
4. Open a .feature file in the Experimental Instance
5. Breakpoint should hit in the main VS window

### Viewing Debug Output

Check the **Output** window in the main VS instance:
- View → Output (Ctrl+Alt+O)
- Select "Debug" or "Visual Studio Extension Host" from dropdown

### Common Issues

**Extension doesn't load:**
- Check Output window for errors
- Verify VSIX manifest is correct
- Try: Extensions → Manage Extensions → Installed → Uninstall old version

**Syntax highlighting doesn't work:**
- Check if .feature file is recognized: View → Properties Window
- Content Type should show "gherkin"
- If not, check GherkinContentTypeDefinition.cs

**Colors look wrong:**
- VS might be in Light Theme - colors optimized for Dark Theme
- Switch to Dark Theme: Tools → Options → Environment → General → Color theme

**Performance issues:**
- Check for infinite loops in parser code
- Profile using Performance Profiler
- Verify tokens are cached appropriately

## Advanced Testing

### Testing with Real Projects

1. Find real .feature files from projects like:
   - SpecFlow examples
   - Cucumber samples
   - Open source projects using BDD

2. Open them in the Experimental Instance
3. Verify highlighting works correctly

### Automated Testing (Future)

For production extensions, consider adding:
- Unit tests for the parser wrapper
- Integration tests for the classifier
- Performance benchmarks

## Reporting Issues

If you find bugs during testing:

1. Note the exact steps to reproduce
2. Capture a screenshot
3. Check Visual Studio logs: `%LOCALAPPDATA%\Microsoft\VisualStudio\17.0_<id>\ActivityLog.xml`
4. Create an issue with all details

## Next Steps After Testing

Once testing is complete and everything works:

1. **Create icon images** (icon.png, preview.png)
2. **Build in Release mode** (Build → Configuration Manager → Release)
3. **Find the VSIX file** in `FeatureHighlighter/bin/Release/FeatureHighlighter.vsix`
4. **Install on your main VS instance** by double-clicking the .vsix
5. **Test in production** with real feature files
6. **Publish to VS Marketplace** (if desired)

## Quick Reference Commands

| Action | Command |
|--------|---------|
| Build solution | `Ctrl+Shift+B` |
| Start debugging (launch Experimental Instance) | `F5` |
| Stop debugging | `Shift+F5` |
| Open file | `Ctrl+O` |
| Open Output window | `Ctrl+Alt+O` |
| Open Error List | `Ctrl+\, E` |

---

Happy testing! 🧪
