Feature: Login

	@GUI
	Scenario: Successful login
	Given open the LoginPage
	When "correct" sign in
	Then user is successfully logged in

	@GUI
	Scenario: Unsuccesful login (использование некорректных данных + всплывающее сообщение)
	Given open the LoginPage
	When "incorrect" sign in
	Then assert error message
