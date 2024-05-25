Feature: movies API

Scenario: Get all movies
	Given the movies service is available
	When a GET request is made to '/api/movies'
	Then the response status code should be '200'
	And the response body should contain a list of movies '[{}]'

Scenario: Get movie by ID
	Given the movies service is available
	When a GET request is made to '/api/movies/{id}'
	Then the response status code should be '200'
	And the response body should contain the movie with the specified ID
	And the response body should not contain any other movies '[{}]'

Scenario: Create movie
	Given the movies service is available
	When a POST request is made to '/api/movies' with a valid request body '{}'
	Then the response status code should be '200'
	And the response body should contain the ID of the created movie '{}'

Scenario: Update movie
	Given the movies service is available
	When a PUT request is made to '/api/movies/{id}' with a valid request body
	Then the response status code should be '200'

Scenario: Delete movie
	Given the movies service is available
	When a DELETE request is made to /api/movies/{id}
	Then the response status code should be '200' 