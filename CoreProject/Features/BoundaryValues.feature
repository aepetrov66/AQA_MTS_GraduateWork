Feature: BoundaryValues

@GUI
Scenario: CreateProject
	Given open the ProjectsPage
	When user clicks Create new project
	And fills the form
	Then enter a new Project repository