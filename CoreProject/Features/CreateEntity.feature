Feature: CreateEntity

	@GUI
	Scenario: PopUpMessage
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fill the NewTestCaseTitle
	And navigate Backward
	Then assert the PopUp

	@GUI
	Scenario: CreateTestCaseEntity
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	Then assert the ProjectRepository page is open
	And new testCase is created

	@GUI
	Scenario: DeleteTestCaseEntity
	Given open the Project
	When user delete TestCase
	Then there is no such testCase

	@GUI
	Scenario: UploadFile
	Given open the Project
	When user clicks CreateTestCaseButton
	And user uploads file
	Then asser the file

	@GUI
	Scenario: AssertFile
	Given open the Project
	Then asser the file