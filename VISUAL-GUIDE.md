# Visual Guide - What to Expect

This guide shows you what syntax highlighting should look like when testing Feature Highlighter.

## Color Reference

When you open a `.feature` file, you should see these colors (optimized for VS Dark Theme):

| Element | Color | Style | Example |
|---------|-------|-------|---------|
| **Keywords** | Blue (#569CD6) | Bold | `Feature`, `Scenario`, `Given`, `When`, `Then`, `And`, `But` |
| **Comments** | Green (#57A64A) | Italic | `# This is a comment` |
| **Tags** | Light Blue (#9CDCFE) | Normal | `@smoke`, `@regression` |
| **Parameters** | Light Green (#B8D7A3) | Normal | `"text"`, `<param>`, `{variable}` |
| **Doc Strings** | Tan/Brown (#CE9178) | Normal | `""" content """` |
| **Table Cells** | Yellow (#DCDCAA) | Normal | Text inside `\| cell \|` |
| **Table Pipes** | Gray (#B0B0B0) | Normal | The `\|` characters |

## Example Feature File with Expected Colors

Imagine these colors when viewing a .feature file:

```gherkin
# [GREEN ITALIC] This is a comment about the feature

@smoke @regression
# [LIGHT BLUE] Both tags above

Feature: User Authentication
# [BLUE BOLD] "Feature" keyword, rest is normal text

  As a registered user
  I want to log in securely
  So that I can access my account
  # [NORMAL TEXT] All description lines

  Background:
  # [BLUE BOLD] "Background" keyword

    Given the application is running
    # [BLUE BOLD] "Given" keyword, rest is normal text

  @positive
  # [LIGHT BLUE] Tag

  Scenario: Successful login with valid credentials
  # [BLUE BOLD] "Scenario" keyword, rest is normal text

    Given I am on the login page
    # [BLUE BOLD] "Given"

    When I enter username "john.doe" and password "secret123"
    # [BLUE BOLD] "When"
    # [LIGHT GREEN] "john.doe" and "secret123"

    And I click the login button
    # [BLUE BOLD] "And"

    Then I should see the dashboard
    # [BLUE BOLD] "Then"

    And I should see a welcome message "Welcome, John!"
    # [BLUE BOLD] "And"
    # [LIGHT GREEN] "Welcome, John!"

  Scenario Outline: Login with different credentials
  # [BLUE BOLD] "Scenario Outline"

    Given I am on the login page
    When I enter username "<username>" and password "<password>"
    # [LIGHT GREEN] <username> and <password>

    Then I should see <result>
    # [LIGHT GREEN] <result>

    Examples:
    # [BLUE BOLD] "Examples"

      | username  | password  | result           |
      # [GRAY] All | pipes
      # [YELLOW] All cell contents: "username", "password", "result"

      | john.doe  | secret123 | dashboard        |
      # [GRAY] All | pipes
      # [YELLOW] All cell contents

      | jane.doe  | pass456   | dashboard        |
      | invalid   | wrong     | error message    |

  Rule: Password must be secure
  # [BLUE BOLD] "Rule"

    Scenario: Password requirements
      Given I am creating a new account
      When I enter a password with {min_length} characters
      # [LIGHT GREEN] {min_length}

      Then the system should validate it
      And I should see the requirements:
        """
        Password must contain:
        - At least 8 characters
        - One uppercase letter
        - One lowercase letter
        - One number
        """
        # [TAN/BROWN] Everything between """ marks
```

## What It Should Look Like in Visual Studio

### Before (No Highlighting)
All text appears in the same color - hard to read and parse visually:

```
# User authentication tests
@smoke @regression
Feature: User Authentication
  Scenario: Successful login
    Given I am on the login page
    When I enter username "john.doe"
    Then I should see the dashboard
```

### After (With Feature Highlighter)
Clear visual hierarchy with color coding:

```gherkin
# [GREEN] User authentication tests
[LIGHT BLUE] @smoke @regression
[BLUE] Feature: User Authentication
  [BLUE] Scenario: Successful login
    [BLUE] Given I am on the login page
    [BLUE] When I enter username [LIGHT GREEN] "john.doe"
    [BLUE] Then I should see the dashboard
```

## Language Variants

The same highlighting works for other languages:

### German
```gherkin
# [GREEN] Deutsche Tests
[LIGHT BLUE] @smoke
[BLUE] Funktionalität: Benutzer-Authentifizierung
  [BLUE] Szenario: Erfolgreiche Anmeldung
    [BLUE] Angenommen ich bin auf der Login-Seite
    [BLUE] Wenn ich meine Daten eingebe
    [BLUE] Dann sollte ich eingeloggt sein
```

### French
```gherkin
# [GREEN] Tests en français
[LIGHT BLUE] @smoke
[BLUE] Fonctionnalité: Authentification utilisateur
  [BLUE] Scénario: Connexion réussie
    [BLUE] Soit je suis sur la page de connexion
    [BLUE] Quand je saisis mes identifiants
    [BLUE] Alors je devrais être connecté
```

### Spanish
```gherkin
# [GREEN] Pruebas en español
[LIGHT BLUE] @smoke
[BLUE] Característica: Autenticación de usuario
  [BLUE] Escenario: Inicio de sesión exitoso
    [BLUE] Dado que estoy en la página de inicio de sesión
    [BLUE] Cuando ingreso mis credenciales
    [BLUE] Entonces debería estar conectado
```

## Testing Checklist

When testing, verify each of these elements is highlighted correctly:

### ✅ Keywords (Blue, Bold)
- [ ] Feature / Funktionalität / Fonctionnalité / Característica
- [ ] Background / Grundlage / Contexte / Antecedentes
- [ ] Scenario / Szenario / Scénario / Escenario
- [ ] Scenario Outline / Szenariogrundriss / Plan du scénario / Esquema del escenario
- [ ] Rule / Regel / Règle / Regla
- [ ] Examples / Beispiele / Exemples / Ejemplos
- [ ] Given / Angenommen / Soit / Dado
- [ ] When / Wenn / Quand / Cuando
- [ ] Then / Dann / Alors / Entonces
- [ ] And / Und / Et / Y
- [ ] But / Aber / Mais / Pero

### ✅ Comments (Green, Italic)
- [ ] Single line comments: `# comment text`
- [ ] Comments with special characters: `# TODO: fix this`

### ✅ Tags (Light Blue)
- [ ] Simple tags: `@smoke`
- [ ] Hyphenated tags: `@smoke-test`
- [ ] Multiple tags: `@smoke @regression @critical`

### ✅ Parameters (Light Green)
- [ ] Angle brackets: `<username>`
- [ ] Curly braces: `{variable}`
- [ ] Double quotes: `"john.doe"`
- [ ] Single quotes: `'secret'`
- [ ] Nested quotes: `"text with 'quotes'"`
- [ ] Escaped quotes: `"text with \" quote"`

### ✅ Doc Strings (Tan/Brown)
- [ ] Opening delimiter: `"""`
- [ ] Content lines
- [ ] Closing delimiter: `"""`
- [ ] Alternative syntax: ` ``` `

### ✅ Tables (Yellow cells, Gray pipes)
- [ ] Header row: `| name | value |`
- [ ] Data rows with proper spacing
- [ ] Empty cells: `| name | |`

## Customizing Colors

If the default colors don't suit your theme, you can customize them:

1. Tools → Options → Environment → Fonts and Colors
2. Show settings for: **Text Editor**
3. Display items → Find these items:
   - Gherkin Keyword
   - Gherkin Comment
   - Gherkin Tag
   - Gherkin Parameter
   - Gherkin Doc String
   - Gherkin Table Cell
   - Gherkin Table Pipe
4. Change Item foreground/background as desired
5. Click OK to apply

## Troubleshooting Visual Issues

**All text is the same color:**
- Verify the file extension is `.feature`
- Check: View → Properties Window → Content Type should be "gherkin"
- Try closing and reopening the file

**Colors look wrong:**
- Default colors optimized for Dark Theme
- If using Light Theme, customize colors (see above)
- Some colors may need adjustment for accessibility

**Keywords not highlighted:**
- Ensure there's a space or colon after the keyword
- Check spelling (case-insensitive but must match Gherkin spec)
- Comments at end of keyword line may prevent highlighting

**Tables look wrong:**
- Ensure proper spacing: `| cell |` not `|cell|`
- All rows should have same number of pipes
- Tables must be indented under a step

---

For more testing details, see [TESTING.md](TESTING.md)
