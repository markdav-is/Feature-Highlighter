@smoke @regression @authentication
# Sample Feature File for Testing Feature Highlighter
# This file demonstrates all syntax elements that should be highlighted

Feature: User Authentication
  As a registered user
  I want to log in to the application
  So that I can access my personal dashboard

  Background:
    Given the application is running
    And the database is populated with test users

  @positive @critical
  Scenario: Successful login with valid credentials
    Given I am on the login page
    When I enter username "john.doe" and password "SecurePass123!"
    And I click the "Sign In" button
    Then I should be redirected to the dashboard
    And I should see a welcome message "Welcome back, John!"
    And the session should be active

  @negative
  Scenario: Failed login with invalid password
    Given I am on the login page
    When I enter username "john.doe" and password "WrongPassword"
    And I click the "Sign In" button
    Then I should see an error message "Invalid credentials"
    And I should remain on the login page
    But the username field should retain the value "john.doe"

  @parameterized
  Scenario Outline: Login attempts with various credentials
    Given I am on the login page
    When I enter username "<username>" and password "<password>"
    And I click the "Sign In" button
    Then I should see <result>
    And the login attempt should be logged with status <status>

    Examples: Valid users
      | username   | password       | result              | status  |
      | john.doe   | SecurePass123! | dashboard           | success |
      | jane.smith | JanePass456!   | dashboard           | success |
      | admin.user | AdminPwd789!   | admin dashboard     | success |

    Examples: Invalid credentials
      | username    | password     | result          | status  |
      | john.doe    | wrong        | error message   | failed  |
      | invalid     | invalid      | error message   | failed  |
      | <hacker>    | {injection}  | error message   | blocked |

  Rule: Password Security Requirements

    Background:
      Given the password policy is configured

    @security
    Scenario: Password must meet minimum requirements
      Given I am creating a new account
      When I attempt to set password <password>
      Then the system should respond with <result>
        """
        Password Policy:
        - Minimum 8 characters
        - At least one uppercase letter
        - At least one lowercase letter
        - At least one number
        - At least one special character
        """

      Examples:
        | password        | result    |
        | short           | rejected  |
        | NoNumbers!      | rejected  |
        | nonumbers123    | rejected  |
        | ValidPass1!     | accepted  |

  @edge-case @data-table
  Scenario: User profile with multiple attributes
    Given a user exists with the following details:
      | Field      | Value                |
      | Username   | john.doe             |
      | Email      | john.doe@example.com |
      | FirstName  | John                 |
      | LastName   | Doe                  |
      | Role       | standard-user        |
      | Status     | active               |
      | Created    | 2024-01-15           |
    When I view the user profile
    Then all fields should display correctly
    And the user should have permissions for {standard-user} role

  @multi-language
  Scenario: Login page displays in user's preferred language
    Given the system supports multiple languages
    And my preferred language is set to "Français"
    When I navigate to the login page
    Then I should see the text "Nom d'utilisateur" instead of "Username"
    And I should see the text "Mot de passe" instead of "Password"
    And the button should say "Se connecter" instead of "Sign In"
