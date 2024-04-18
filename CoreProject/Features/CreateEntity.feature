Feature: CreateEntity

@GUI
Scenario: PopUpMessage
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fill the NewTestCaseTitle
	And navigate Backward
	Then assert the PopUp