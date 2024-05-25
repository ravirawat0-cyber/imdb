Feature: Genre API

Scenario: Get all genres
	Given the genres service is available
	When a GET request is made to '/api/genres'
	Then the response status code should be '200'
	And the response body should contain a list of genres '[{}]'

Scenario: Get genre by ID
	Given the genres service is available
	When a GET request is made to '/api/genres/{id}'
	Then the response status code should be '200'
	And the response body should contain the genre with the specified ID
	And the response body should not contain any other genres '[{}]'

Scenario: Create genre
	Given the genres service is available
	When a POST request is made to '/api/genres' with a valid request body '{}'
	Then the response status code should be '200'
	And the response body should contain the ID of the created genre '{}'

Scenario: Update genre
	Given the genres service is available
	When a PUT request is made to '/api/genres/{id}' with a valid request body
	Then the response status code should be '200'

Scenario: Delete genre
	Given the genres service is available
	When a DELETE request is made to /api/genres/{id}
	Then the response status code should be '200' 