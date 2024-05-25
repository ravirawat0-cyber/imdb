Feature: Actors API

Scenario: Get all actors
Given the actors service is available
When a GET request is made to '/api/actors'
Then the response status code should be '200'
And the response body should contain a list of actors '[{}]'

Scenario: Get actor by ID
Given the actors service is available
When a GET request is made to '/api/actors/{id}'
Then the response status code should be '200'
And the response body should contain the actor with the specified ID
And the response body should not contain any other actors '[{}]'

Scenario: Create actor
Given the actors service is available
When a POST request is made to '/api/actors' with a valid request body '{}'
Then the response status code should be '200'
And the response body should contain the ID of the created actor '{}'

Scenario: Update actor
Given the actors service is available
When a PUT request is made to '/api/actors/{id}' with a valid request body
Then the response status code should be '200'

Scenario: Delete actor
Given the actors service is available
When a DELETE request is made to /api/actors/{id}
Then the response status code should be '200' 
