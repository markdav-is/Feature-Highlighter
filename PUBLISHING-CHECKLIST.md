# Publishing Checklist

Quick reference checklist for publishing Feature Highlighter to Visual Studio Marketplace.

📖 For detailed instructions, see [PUBLISHING.md](PUBLISHING.md)

## Pre-Publishing Checklist

### ✅ Assets & Files

- [ ] **Icon created** - `FeatureHighlighter/Resources/icon.png` (128x128 PNG)
- [ ] **Preview image created** - `FeatureHighlighter/Resources/preview.png` (1280x720 PNG)
- [ ] **Placeholder files deleted** - Remove `.txt` files from Resources folder
- [ ] **License file present** - LICENSE file exists in root (✅ already exists)
- [ ] **README complete** - Has installation, usage, features documented (✅ done)

### ✅ Code Quality

- [ ] **Extension tested** - Tested in Experimental Instance (see [TESTING.md](TESTING.md))
- [ ] **All features work** - All syntax elements highlight correctly
- [ ] **No errors** - Solution builds without errors or warnings
- [ ] **Multi-language tested** - Tested with English, German, French feature files
- [ ] **Performance verified** - Tested with large files (1000+ lines)

### ✅ Manifest & Metadata

- [ ] **Version number set** - Version in `source.extension.vsixmanifest` is correct (e.g., 1.0.0)
- [ ] **DisplayName correct** - "Feature Highlighter"
- [ ] **Description clear** - Concise explanation of what extension does
- [ ] **Tags added** - gherkin, cucumber, bdd, feature, syntax highlighting
- [ ] **GitHub URL set** - MoreInfo points to your repository
- [ ] **Icon/preview paths correct** - Points to Resources\icon.png and preview.png

### ✅ Documentation

- [ ] **README.md updated** - Installation instructions reference marketplace
- [ ] **CHANGELOG.md created** - Document version 1.0.0 features (optional but recommended)
- [ ] **CONTRIBUTING.md present** - (✅ done)
- [ ] **Test files included** - TestFiles/sample.feature exists (✅ done)

## Publishing Steps

### Step 1: Build Release Package

```bash
# Open solution in Visual Studio 2022
start FeatureHighlighter.sln

# In Visual Studio:
# 1. Build → Configuration Manager → Set to "Release"
# 2. Build → Clean Solution
# 3. Build → Build Solution
# 4. Verify: FeatureHighlighter/bin/Release/FeatureHighlighter.vsix exists
```

- [ ] **Release build created** - VSIX file in bin/Release folder
- [ ] **Build succeeded** - No errors or warnings
- [ ] **VSIX file size reasonable** - Should be < 5 MB

### Step 2: Test Release Build

- [ ] **Install VSIX locally** - Double-click the .vsix file
- [ ] **Restart Visual Studio**
- [ ] **Open .feature file** - Verify highlighting works
- [ ] **Test all features** - Keywords, comments, tags, parameters, tables, doc strings
- [ ] **Uninstall test version** - Extensions → Manage Extensions → Uninstall

### Step 3: Create Publisher Account (First Time Only)

- [ ] **Go to marketplace** - https://marketplace.visualstudio.com/manage
- [ ] **Sign in** - Use Microsoft Account
- [ ] **Create publisher** - If you don't have one
- [ ] **Choose publisher ID** - Lowercase, no spaces (e.g., "markdavis")
- [ ] **Set publisher name** - Your name or company
- [ ] **Add contact email**

### Step 4: Upload to Marketplace

- [ ] **Go to publish page** - https://marketplace.visualstudio.com/manage
- [ ] **Click "+ New Extension"**
- [ ] **Select "Visual Studio"** (not VS Code!)
- [ ] **Upload VSIX file** - Drag and drop FeatureHighlighter.vsix
- [ ] **Verify auto-filled details** - Check name, description, etc.
- [ ] **Add/update description** - Use Markdown, copy from README
- [ ] **Set categories** - "Language Support", "Testing"
- [ ] **Add tags** - gherkin, cucumber, bdd, specflow, reqnroll, feature, syntax
- [ ] **Set repository URL** - https://github.com/markdav-is/Feature-Highlighter
- [ ] **Set license URL** - Link to LICENSE file on GitHub
- [ ] **Set issue tracker** - GitHub issues URL
- [ ] **Add screenshots** (optional but recommended) - Show highlighting in action
- [ ] **Set pricing** - Free
- [ ] **Enable Q&A** - Allow users to ask questions
- [ ] **Enable reviews** - Allow ratings

### Step 5: Submit & Verify

- [ ] **Click "Publish"**
- [ ] **Wait for validation** - Usually takes a few minutes
- [ ] **Check for errors** - Fix any validation issues
- [ ] **Verify listing** - Visit your marketplace page
- [ ] **Test download** - Try downloading and installing from marketplace
- [ ] **Check all links** - Ensure repository, license, issues links work

## Post-Publishing Checklist

### ✅ Update Repository

- [ ] **Add marketplace badge** - Add to README.md
  ```markdown
  [![VS Marketplace](https://img.shields.io/visual-studio-marketplace/v/PUBLISHER.FeatureHighlighter)](https://marketplace.visualstudio.com/items?itemName=PUBLISHER.FeatureHighlighter)
  ```
- [ ] **Update installation section** - Reference marketplace as primary method
- [ ] **Create GitHub release** - Tag v1.0.0 with release notes
- [ ] **Attach VSIX to release** - Upload the .vsix file to GitHub release

### ✅ Announce & Promote

- [ ] **Share on Twitter/X** - #VisualStudio #BDD #Gherkin #Cucumber
- [ ] **Post on Reddit** - r/dotnet, r/VisualStudio, r/BDD
- [ ] **LinkedIn announcement** - Share with professional network
- [ ] **Write blog post** - Dev.to, Medium, personal blog
- [ ] **Update personal website** - Add to portfolio/projects

### ✅ Monitor & Maintain

- [ ] **Check marketplace stats** - Downloads, ratings, reviews
- [ ] **Respond to Q&A** - Answer user questions promptly
- [ ] **Monitor GitHub issues** - Address bug reports and feature requests
- [ ] **Plan updates** - Based on user feedback

## Quick Commands Reference

```bash
# Build release version
msbuild FeatureHighlighter.sln /p:Configuration=Release

# Find the VSIX
ls FeatureHighlighter/bin/Release/*.vsix

# Create git tag for release
git tag -a v1.0.0 -m "Release version 1.0.0"
git push origin v1.0.0
```

## Important URLs

| Resource | URL |
|----------|-----|
| Marketplace Publisher Portal | https://marketplace.visualstudio.com/manage |
| Create Publisher | https://marketplace.visualstudio.com/manage/createpublisher |
| VS Marketplace (Search) | https://marketplace.visualstudio.com/vs |
| VSIX Publishing Docs | https://learn.microsoft.com/en-us/visualstudio/extensibility/walkthrough-publishing-a-visual-studio-extension |

## Version Numbers (Semantic Versioning)

- **1.0.0** - Initial release
- **1.0.x** - Bug fixes only
- **1.x.0** - New features (backward compatible)
- **x.0.0** - Breaking changes

## Common Issues

| Issue | Solution |
|-------|----------|
| Validation failed | Check manifest XML, ensure icon/preview included |
| Images not showing | Verify paths, ensure marked as Content in .csproj |
| Publisher not found | Create publisher account first |
| VSIX too large | Should be < 5MB, check what's included |
| Can't find extension | May take a few hours to appear in search |

## After First Publish

For future updates:

1. Update version number in manifest
2. Update CHANGELOG.md
3. Build release version
4. Go to marketplace manage page
5. Click on your extension → Update
6. Upload new VSIX
7. Add release notes
8. Submit

---

**Status Tracking:**

- [ ] Pre-publishing complete
- [ ] Assets created
- [ ] Release built and tested
- [ ] Published to marketplace
- [ ] Repository updated
- [ ] Announced publicly
- [ ] Monitoring user feedback

**Current Version:** ___________

**Marketplace URL:** ___________

**First Published:** ___________
