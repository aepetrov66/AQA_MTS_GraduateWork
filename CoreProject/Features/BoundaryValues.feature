Feature: BoundaryValues

	@GUI
	Scenario: CreateProjectWithIncorrectCode (���� ������ ����������� ���������� + ����������� ���������)
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Incorrect" project
	Then Project is not created

	@GUI
	Scenario: CreateProject (�������� ���� ��� ����� �� ��������� ��������)
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Correct" project
	Then enter a new Project repository