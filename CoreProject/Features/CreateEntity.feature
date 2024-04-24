@allure.label.epic:GUI
@allure.label.suite:GUI
@allure.label.subSuite:CreateEntity
Feature: CreateEntity

	@allure.label.story:EntityTest
	@ENTITY
	Scenario: PopUpMessage
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	And navigate Backward
	Then assert the PopUp

	@allure.label.story:EntityTest
	@ENTITY
	Scenario: CreateTestCaseEntity
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	Then assert the ProjectRepository page is open
	And new testCase is created

	@allure.label.story:EntityTest
	@ENTITY
	Scenario: DeleteTestCaseEntity
	Given open the Project
	When user delete TestCase
	Then there is no such testCase

	@allure.label.story:EntityTest
	@ENTITY
	Scenario: UploadFile
	Given open the Project
	When user clicks CreateTestCaseButton
	And user uploads file
	Then assert the file

	@allure.label.story:EntityTest
	@ENTITY
	Scenario: AssertFile
	Given open the Project
	Then fail