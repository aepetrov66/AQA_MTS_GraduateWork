Feature: Login

@GUI
Scenario: Successful login
	Given open the LoginPage
	When sign in
	Then user is successfully logged in