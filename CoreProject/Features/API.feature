Feature: API

	@API
	Scenario: Get all testcases
	Given getProjects request to the endpoint

	@API
	Scenario: Get a project
	Given getProject request to the endpoint

	@API
	Scenario: Get Unauthorized error
	Given unauthorized request to the endpoint

	@API
	Scenario: Not found project
	Given getUnexistingProject request to the endpoint

	@API
	Scenario: Not found
	Given getProject bad request to the endpoint

	@API
	Scenario: Invalid data
	Given postProject with invalid data

	@API
	Scenario: Post project
	Given postProjectRequest to the endpoint