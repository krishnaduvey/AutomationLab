Feature: TextBox Form

  Scenario: User submits textbox form successfully
    Given user is on demoqa textbox page
    When user submits textbox form
    Then submitted name should be displayed
