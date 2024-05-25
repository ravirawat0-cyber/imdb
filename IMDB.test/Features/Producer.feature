Feature: Producers API

Scenario: Get all Producers
	Given the Producers service is available
	When a GET request is made to '/api/Producers'
	Then the response status code should be '200'
	And the response body should contain a list of Producers '[{}]'

Scenario: Get producer by ID
	Given the Producers service is available
	When a GET request is made to '/api/Producers/{id}'
	Then the response status code should be '200'
	And the response body should contain the producer with the specified ID
	And the response body should not contain any other Producers '[{}]'

Scenario: Create producer
	Given the producers service is available
	When a POST request is made to '/api/producers' with a valid request body '{}'
	Then the response status code should be '200'
	And the response body should contain the ID of the created producer '{}'

Scenario: Update producer
	Given the Producers service is available
	When a PUT request is made to '/api/Producers/{id}' with a valid request body
	Then the response status code should be '200'

Scenario: Delete producer
	Given the Producers service is available
	When a DELETE request is made to /api/Producers/{id}
	Then the response status code should be '200' 
