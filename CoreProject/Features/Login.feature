@allure.label.epic:GUI
@allure.label.suite:GUI
@allure.label.subSuite:Login
Feature: Login

	@allure.label.story:LoginTest
	@GUI
	Scenario: Unsuccesful login
	Given open the LoginPage
	When "incorrect" sign in
	Then assert error message

	@allure.label.story:LoginTest
	@GUI
	Scenario: Successful login
	Given open the LoginPage
	When "correct" sign in
	Then user is successfully logged in
