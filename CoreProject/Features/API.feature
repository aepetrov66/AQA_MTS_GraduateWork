@allure.label.epic:API
@allure.label.suite:API
@allure.label.subSuite:APItests
Feature: API

	@allure.label.story:API
	@API
	Scenario: Get all testcases
	Given getProjects request to the endpoint

	@allure.label.story:API
	@API
	Scenario: Get a project
	Given getProject request to the endpoint

	@allure.label.story:API
	@API
	Scenario: Get Unauthorized error
	Given unauthorized request to the endpoint

	@allure.label.story:API
	@API
	Scenario: Not found project
	Given getUnexistingProject request to the endpoint

	@allure.label.story:API
	@API
	Scenario: Not found
	Given getProject bad request to the endpoint

	@allure.label.story:API
	@API
	Scenario: Invalid data
	Given postProject with invalid data

	@allure.label.story:API
	@API
	Scenario: Post project
	Given postProjectRequest to the endpoint