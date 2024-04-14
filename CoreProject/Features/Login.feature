Feature: Login functionality

    @GUI
    Scenario: Successful login
        Given open the login page
        When user enter "correctUsername" to the email field
        * user enter "correctPassword" to the password field
        * user clicks the log in button
        Then user is successfully logged in