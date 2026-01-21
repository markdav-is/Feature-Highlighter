# Resources Folder

This folder contains visual assets for the Feature Highlighter extension.

## Required Files

### icon.png (128x128 pixels)

The extension icon displayed in the Extensions Manager and Visual Studio Marketplace.

**Specifications:**
- Size: 128x128 pixels
- Format: PNG with transparency
- Design: Should represent Gherkin/feature files (e.g., cucumber, file icon, or abstract representation)
- Colors: Green (#57A64A) and Blue (#569CD6) recommended to match syntax highlighting

**Design Suggestions:**
- A file/document icon with ".feature" visible
- A cucumber slice or gherkin pickle graphic
- Abstract shapes forming a "G" for Gherkin
- Modern, flat design style
- Clear at small sizes

### preview.png (600x400 or larger)

A preview image showing the syntax highlighting in action.

**Specifications:**
- Size: 600x400 pixels minimum (1200x800 recommended)
- Format: PNG
- Content: Screenshot of Visual Studio with a highlighted .feature file

**What to Show:**
- Feature and Scenario keywords (blue, bold)
- Given/When/Then steps (blue, bold)
- Comments starting with # (green, italic)
- Tags like @smoke (light blue)
- Parameters like <param> or "text" (light green)
- Data tables with | cells | (yellow cells, gray pipes)
- Doc strings with """ (tan/brown)

**Screenshot Tips:**
- Use Visual Studio 2022 Dark Theme
- Show a representative feature file
- Zoom for readability
- Crop to focus on the editor
- High quality, crisp text

## Creating the Images

### Quick Placeholder (for testing)

If you need quick placeholders for testing:

```bash
# Using ImageMagick (if available)
convert -size 128x128 xc:#57A64A -fill white -font Arial -pointsize 48 \
  -gravity center -annotate +0+0 'F' icon.png

convert -size 600x400 xc:#1E1E1E -fill #569CD6 -font Courier -pointsize 16 \
  -gravity center -annotate +0+0 'Feature Highlighter\nSyntax Highlighting' preview.png
```

### Professional Images

For production-ready images, use:
- **Icon Design:** Figma, Adobe Illustrator, Inkscape, or Canva
- **Screenshot:** Windows Snipping Tool, ShareX, or Greenshot

## Current Status

Replace the `.txt` placeholder files with actual PNG files before building the final VSIX package.
