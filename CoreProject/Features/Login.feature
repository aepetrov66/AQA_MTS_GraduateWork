Feature: Login functionality

@GUI
Scenario: Successful login
	Given open the login page
	When user enter "relatrus@gmail.com" to the email field
	* user enter "Youcannotenter#3" to the password field
	* user clicks the log in button
	Then user is successfully logged in