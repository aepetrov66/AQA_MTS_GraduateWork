@allure.label.epic:GUI
@allure.label.suite:GUI
@allure.label.subSuite:BoundaryValues
Feature: BoundaryValues

	@allure.label.story:BoundaryValues
	@allure.label.severity:critical
	@allure.label.owner:JohnDoe
	@link:https://dev.example.com/
	@issue:AUTH-123
	@tms:TMS-456
	@allure.label.package:org.example
	@allure.label.testClass:TestMyWebsite
	@allure.label.testMethod:TestLabels()
	@GUI
	Scenario: CreateProjectWithIncorrectCode
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Incorrect" project
	Then Project is not created

	@allure.label.story:BoundaryValues
	@allure.label.severity:critical
	@allure.label.owner:JohnDoe
	@link:https://dev.example.com/
	@issue:AUTH-1234
	@tms:TMS-457
	@allure.label.package:org.example
	@allure.label.testClass:TestMyWebsite
	@allure.label.testMethod:TestLabels()
	@GUI
	Scenario: CreateProject
	Given open the ProjectsPage
	When user clicks Create new project
	And creates a "Correct" project
	Then enter a new Project repository