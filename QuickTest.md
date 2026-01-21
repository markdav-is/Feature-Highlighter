# Quick Test Guide (2 Minutes)

The fastest way to test the Feature Highlighter extension.

## Prerequisites

- Visual Studio 2022 installed
- Visual Studio Extension Development workload installed

## Steps

### 1. Open Solution (10 seconds)

**Windows:**
```cmd
cd path\to\Feature-Highlighter
start FeatureHighlighter.sln
```

**Or:** Double-click `FeatureHighlighter.sln` in File Explorer

### 2. Build (30 seconds)

In Visual Studio:
- Press `Ctrl+Shift+B` to build
- Wait for "Build succeeded" in the status bar

### 3. Launch Test Environment (30 seconds)

- Press `F5` (Start Debugging)
- A new VS window opens titled "**Microsoft Visual Studio (Experimental Instance)**"
- Wait for it to finish loading

### 4. Open Test File (20 seconds)

In the **Experimental Instance** window:
1. Press `Ctrl+O` (Open File)
2. Navigate to: `Feature-Highlighter\TestFiles\sample.feature`
3. Open the file

### 5. Verify Highlighting (10 seconds)

**You should see:**
- ✅ Blue, bold keywords: `Feature`, `Scenario`, `Given`, `When`, `Then`
- ✅ Green, italic comments: `# comment text`
- ✅ Light blue tags: `@smoke @regression`
- ✅ Light green parameters: `"john.doe"`, `<param>`, `{variable}`
- ✅ Yellow table cells and gray pipes: `| cell |`
- ✅ Tan/brown doc strings: `""" text """`

## ✅ Success!

If you see the colors above, the extension is working!

## ❌ Not Working?

**No syntax highlighting at all:**
1. Check the file extension is `.feature`
2. Try closing and reopening the file
3. Check Output window (View → Output) for errors

**Build failed:**
1. Right-click solution → Restore NuGet Packages
2. Build → Clean Solution
3. Build → Build Solution

**Experimental Instance won't start:**
1. Close all VS instances
2. Delete: `%LOCALAPPDATA%\Microsoft\VisualStudio\17.0_<id>Exp`
3. Try again

## Next Steps

For detailed testing, see [TESTING.md](TESTING.md)

## Quick Modifications to Test

Try editing the test file in the Experimental Instance:

```gherkin
# Type this and watch it highlight:
@my-tag
Feature: My Test Feature
  Scenario: My test scenario
    Given I have a parameter "value"
    When I use <placeholder>
    Then I see a table:
      | name  | value |
      | test  | 123   |
```

All elements should highlight as you type!
