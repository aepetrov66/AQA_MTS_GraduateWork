Feature: BoundaryValues

	@GUI
	Scenario: CreateProjectWithIncorrectCode (ввод данных превышающих допустимые + всплывающее сообщение)
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Incorrect" project
	Then Project is not created

	@GUI
	Scenario: CreateProject (проверка поля для ввода на граничные значения)
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Correct" project
	Then enter a new Project repository