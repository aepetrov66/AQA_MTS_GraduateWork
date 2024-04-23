Feature: CreateEntity

	@ENTITY
	Scenario: PopUpMessage (���� ����������� ����������� ����)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	And navigate Backward
	Then assert the PopUp

	@ENTITY
	Scenario: CreateTestCaseEntity (���� �� �������� ��������)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user fills the TestCaseBasic
	Then assert the ProjectRepository page is open
	And new testCase is created

	@ENTITY
	Scenario: DeleteTestCaseEntity (���� �� �������� ��������)
	Given open the Project
	When user delete TestCase
	Then there is no such testCase

	@ENTITY
	Scenario: UploadFile (���� �� �������� �����)
	Given open the Project
	When user clicks CreateTestCaseButton
	And user uploads file
	Then assert the file

	@ENTITY
	Scenario: AssertFile (���� ��������������� ����� ������)
	Given open the Project
	Then assert the file