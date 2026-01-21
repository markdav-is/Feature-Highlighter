# Publishing to Visual Studio Marketplace

This guide walks you through publishing the Feature Highlighter extension to the Visual Studio Marketplace.

## Prerequisites

Before you can publish, you need:

1. ✅ **Working extension** - Test thoroughly first (see [TESTING.md](TESTING.md))
2. ✅ **Visual Studio 2022** with extension development workload
3. ✅ **Microsoft Account** (MSA) - Live.com, Outlook.com, or Azure AD account
4. ✅ **Publisher Account** on Visual Studio Marketplace (free to create)
5. ✅ **Icon and preview images** created (see step 1 below)

## Step 1: Prepare Required Assets

### Create Icon (Required)

Create `FeatureHighlighter/Resources/icon.png`:
- **Size:** 128x128 pixels
- **Format:** PNG with transparency
- **Design:** Something representing Gherkin/feature files
- **Suggestions:**
  - File icon with ".feature" text
  - Cucumber/gherkin graphic
  - Abstract "G" or "F" design
  - Use colors: Green (#57A64A) and Blue (#569CD6)

**Tools to create icon:**
- [Figma](https://figma.com) (free)
- [Canva](https://canva.com) (free)
- [GIMP](https://www.gimp.org/) (free)
- Adobe Illustrator/Photoshop
- [Favicon.io](https://favicon.io/favicon-generator/) for simple text icons

### Create Preview Image (Required)

Create `FeatureHighlighter/Resources/preview.png`:
- **Size:** 1280x720 pixels recommended (minimum 600x400)
- **Format:** PNG
- **Content:** Screenshot of VS with highlighted .feature file

**How to create:**
1. Open Visual Studio with Dark Theme
2. Open `TestFiles/sample.feature` with the extension installed
3. Zoom to comfortable reading size (100-125%)
4. Take screenshot (Windows: Win+Shift+S)
5. Crop to show just the editor area with highlighted code
6. Save as `preview.png`

**What to show in screenshot:**
- Feature and Scenario keywords (blue, bold)
- Comments (green, italic)
- Tags (light blue)
- Parameters (light green)
- A data table (yellow/gray)
- Doc string if possible (tan/brown)

### Delete Placeholder Files

```bash
# Remove the placeholder .txt files
rm FeatureHighlighter/Resources/icon.png.txt
rm FeatureHighlighter/Resources/preview.png.txt
```

## Step 2: Verify VSIX Manifest Metadata

Your `source.extension.vsixmanifest` should have proper metadata. Verify these fields are correct:

- **DisplayName:** Feature Highlighter
- **Description:** Clear, concise description (shows in marketplace)
- **MoreInfo:** Your GitHub repo URL
- **Icon:** Resources\icon.png
- **PreviewImage:** Resources\preview.png
- **Tags:** Relevant keywords (gherkin, cucumber, bdd, feature, syntax highlighting)

The manifest is already configured, but double-check before building.

## Step 3: Build Release Version

### Build the VSIX Package

1. Open `FeatureHighlighter.sln` in Visual Studio 2022
2. Set build configuration to **Release**:
   - Build → Configuration Manager
   - Active solution configuration → **Release**
   - Click Close
3. Clean and rebuild:
   - Build → Clean Solution
   - Build → Build Solution
4. Verify build succeeded (check Output window)

### Locate the VSIX File

The built extension will be at:
```
FeatureHighlighter/bin/Release/FeatureHighlighter.vsix
```

### Test the Release Build

**IMPORTANT:** Always test the release build before publishing!

1. Double-click the `FeatureHighlighter.vsix` file to install it
2. Restart Visual Studio 2022
3. Open a .feature file and verify highlighting works
4. Check: Extensions → Manage Extensions → Installed → Feature Highlighter appears
5. Test all features one more time

**Uninstall test version:**
- Extensions → Manage Extensions → Installed
- Find "Feature Highlighter"
- Click Uninstall
- Restart Visual Studio

## Step 4: Create Publisher Account

### Sign Up for Visual Studio Marketplace

1. Go to [Visual Studio Marketplace Publisher Management](https://marketplace.visualstudio.com/manage)
2. Sign in with your Microsoft Account
3. Click **"Create Publisher"** (if you don't have one)

### Create Publisher Profile

Fill in the details:
- **Publisher Name:** Your name or company (e.g., "Mark Davis")
  - This appears as the author on the marketplace
  - Cannot be changed easily, choose carefully!
- **Publisher ID:** Unique identifier (e.g., "markdavis" or "markdav-is")
  - Used in URLs: `marketplace.visualstudio.com/publishers/YOUR-ID`
  - Lowercase, no spaces
- **Email:** Contact email for support inquiries
- **Website:** Your website or GitHub profile (optional)

Click **Create** to create your publisher account.

## Step 5: Upload Extension to Marketplace

### Upload via Web Portal

1. Go to [Marketplace Publish](https://marketplace.visualstudio.com/manage/createpublisher)
2. Sign in with your Microsoft Account
3. Click **"+ New Extension"**
4. Select **"Visual Studio"** (not VS Code!)

### Fill in Extension Details

**Upload VSIX:**
- Drag and drop or browse to your `FeatureHighlighter.vsix` file
- Wait for upload to complete

**Extension Information** (auto-populated from manifest, but you can override):
- **Display Name:** Feature Highlighter
- **Unique ID:** Should match your manifest ID
- **Short Description:** One-line summary (160 chars max)
  - Example: "Lightweight syntax highlighting for Gherkin/Cucumber .feature files"
- **Long Description:** Detailed description (can use Markdown!)
  - Copy from your README.md
  - Include features, screenshots, examples
- **Categories:** Select relevant categories
  - "Coding" → "Language Support"
  - "Other" → "Testing"
- **Tags:** Add searchable keywords
  - gherkin, cucumber, bdd, specflow, reqnroll, feature, syntax, highlighting

**Links:**
- **Repository:** https://github.com/markdav-is/Feature-Highlighter
- **License:** https://github.com/markdav-is/Feature-Highlighter/blob/main/LICENSE
- **Getting Started:** Link to README

**Support:**
- **Q&A:** Enable marketplace Q&A
- **Reviews:** Enable reviews
- **Issue Tracker:** https://github.com/markdav-is/Feature-Highlighter/issues

### Pricing & Licensing

- **Pricing:** Free
- **License:** MIT License (already in your repo)

### Submit for Publication

1. Review all information carefully
2. Click **"Upload"** or **"Publish"**
3. Wait for validation (usually a few minutes)
4. If validation passes, extension goes live!

## Step 6: Marketplace Listing Best Practices

### Write a Compelling Description

Use Markdown to format your marketplace description. Here's a template:

```markdown
# Feature Highlighter

**Lightweight syntax highlighting for Gherkin/Cucumber .feature files**

## What It Does

Feature Highlighter brings beautiful, accurate syntax highlighting to your BDD feature files.

✅ Keywords highlighted (Feature, Scenario, Given, When, Then)
✅ Comments, tags, parameters, doc strings, tables
✅ Multi-language support (English, German, French, Spanish, etc.)
✅ Uses Reqnroll Gherkin parser for accuracy
✅ Minimal and fast - focused only on highlighting

## What It Does NOT Do

This extension is intentionally minimal:

❌ No test generation or execution
❌ No IntelliSense or autocomplete
❌ No step navigation

For full BDD features, use SpecFlow or Reqnroll extensions.

## Installation

1. Install from the marketplace
2. Restart Visual Studio 2022
3. Open any .feature file
4. Enjoy beautiful syntax highlighting!

## Customization

Customize colors: Tools → Options → Fonts and Colors → Look for "Gherkin" items

## Support

- [Documentation](https://github.com/markdav-is/Feature-Highlighter)
- [Issues](https://github.com/markdav-is/Feature-Highlighter/issues)
- [Contributing](https://github.com/markdav-is/Feature-Highlighter/blob/main/CONTRIBUTING.md)

Made with ❤️ for the BDD community
```

### Add Screenshots

Upload additional screenshots showing:
1. Full feature file with highlighting
2. Multi-language example (German/French)
3. Data tables highlighted
4. Customization options in Fonts and Colors
5. Before/after comparison (optional)

### Set a Good Icon

Your icon appears in search results - make it recognizable!

## Step 7: After Publishing

### Verify Listing

1. Go to marketplace: `https://marketplace.visualstudio.com/items?itemName=YOUR-PUBLISHER.FeatureHighlighter`
2. Verify all information displays correctly
3. Test the "Download" button
4. Check that screenshots and images load

### Update README.md

Add marketplace badge to your README:

```markdown
[![Visual Studio Marketplace](https://img.shields.io/visual-studio-marketplace/v/YOUR-PUBLISHER.FeatureHighlighter)](https://marketplace.visualstudio.com/items?itemName=YOUR-PUBLISHER.FeatureHighlighter)
[![Downloads](https://img.shields.io/visual-studio-marketplace/d/YOUR-PUBLISHER.FeatureHighlighter)](https://marketplace.visualstudio.com/items?itemName=YOUR-PUBLISHER.FeatureHighlighter)
[![Rating](https://img.shields.io/visual-studio-marketplace/r/YOUR-PUBLISHER.FeatureHighlighter)](https://marketplace.visualstudio.com/items?itemName=YOUR-PUBLISHER.FeatureHighlighter)
```

Update installation instructions:

```markdown
## Installation

### From Visual Studio Marketplace (Recommended)

1. Open Visual Studio 2022
2. Go to **Extensions → Manage Extensions**
3. Search for "Feature Highlighter"
4. Click **Download** and restart Visual Studio

### From VSIX File

Download the latest `.vsix` from [Releases](https://github.com/markdav-is/Feature-Highlighter/releases)
```

### Announce Your Extension

Share on:
- Twitter/X with hashtags: #VisualStudio #BDD #Gherkin #Cucumber
- Reddit: r/dotnet, r/VisualStudio, r/BDD
- Dev.to blog post
- LinkedIn
- Your blog/website

## Step 8: Publishing Updates

When you have updates:

### Version Updates

1. Update version in `source.extension.vsixmanifest`:
   ```xml
   <Identity Id="..." Version="1.1.0" ... />
   ```

2. Follow semantic versioning:
   - **1.0.0** → **1.0.1** - Bug fixes
   - **1.0.0** → **1.1.0** - New features (backward compatible)
   - **1.0.0** → **2.0.0** - Breaking changes

3. Update changelog in README.md

### Upload New Version

1. Build release version with new version number
2. Go to [Marketplace Management](https://marketplace.visualstudio.com/manage)
3. Click on your extension
4. Click **"Update"**
5. Upload new VSIX file
6. Update release notes
7. Submit

Users will be notified of updates automatically in Visual Studio.

## Troubleshooting Publishing Issues

### "Validation Failed"

Common issues:
- Missing or invalid icon/preview images
- Manifest XML errors
- Missing required fields
- Icon/preview files not included in VSIX

**Fix:** Check Output window during build for warnings

### "Publisher Not Found"

- Ensure you've created a publisher account
- Sign in with the same Microsoft Account
- Publisher ID must match

### "VSIX Upload Failed"

- File size limit is 50MB (extension should be much smaller)
- Ensure VSIX file isn't corrupted
- Try building again

### Images Not Showing

- Ensure images are marked as Content in .csproj
- Verify paths in manifest are correct
- Images must be PNG format
- Check image file sizes (icon: 128x128, preview: at least 600x400)

## Marketplace Statistics

After publishing, you can track:
- **Downloads** - How many times installed
- **Ratings** - User reviews and star ratings
- **Q&A** - User questions and your responses
- **Reports** - Detailed analytics

Access at: [Marketplace Management](https://marketplace.visualstudio.com/manage)

## Best Practices

1. **Test thoroughly** before publishing
2. **Respond to reviews** and Q&A questions promptly
3. **Keep extension updated** for new VS versions
4. **Monitor issues** on GitHub
5. **Version carefully** - use semantic versioning
6. **Communicate changes** - write clear release notes
7. **Keep it simple** - don't bloat the extension
8. **Listen to users** - implement requested features thoughtfully

## Resources

- [Visual Studio Marketplace](https://marketplace.visualstudio.com/)
- [Publisher Portal](https://marketplace.visualstudio.com/manage)
- [VSIX Publishing Guide](https://learn.microsoft.com/en-us/visualstudio/extensibility/walkthrough-publishing-a-visual-studio-extension)
- [Extension Manifest Reference](https://learn.microsoft.com/en-us/visualstudio/extensibility/vsix-extension-schema-2-0-reference)

---

**Ready to publish? Follow the steps above and share your extension with the world! 🚀**
