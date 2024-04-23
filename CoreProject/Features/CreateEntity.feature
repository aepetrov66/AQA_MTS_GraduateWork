Feature: CreateEntity

	@ENTITY
	Scenario: PopUpMessage (тест отображения диалогового окна)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	And navigate Backward
	Then assert the PopUp

	@ENTITY
	Scenario: CreateTestCaseEntity (тест на создание сущности)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	Then assert the ProjectRepository page is open
	And new testCase is created

	@ENTITY
	Scenario: DeleteTestCaseEntity (тест на удаление сущности)
	Given open the Project
	When user delete TestCase
	Then there is no such testCase

	@ENTITY
	Scenario: UploadFile (тест на загрузку файла)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user uploads file
	Then assert the file

	@ENTITY
	Scenario: AssertFile (тест воспроизводящий любой дефект)
	Given open the Project
	Then assert the file