Feature: Reviews API

Scenario: Get all reviews for a movie
	Given the review service is available
	When a GET request is made to '/api/reviews/{movieId}'
	Then the response status code should be '200'
	And the response body should contain a list of reviews for the specified movie '[{}]'

Scenario: Get review by ID for a movie
	Given the review service is available
	When a GET request is made to '/api/reviews/{movieId}/{id}'
	Then the response status code should be '200'
	And the response body should not contain any other reviews '[{}]'

Scenario: Create review for a movie
	Given the review service is available
	When a POST request is made to '/api/reviews/{movieId}' with a valid request body '{}'
	Then the response status code should be '200'
	And the response body should contain the ID of the created review '{}'

Scenario: Update review for a movie
	Given the review service is available
	When a PUT request is made to '/api/reviews/{movieId}/{id}' with a valid request body
	Then the response status code should be '200'

Scenario: Delete review for a movie
	Given the review service is available
	When a DELETE request is made to '/api/reviews/{movieId}/{id}'
	Then the response status code should be '200'