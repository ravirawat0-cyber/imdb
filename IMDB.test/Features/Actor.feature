Feature: Actors API

Scenario: Get all actors
	Given the service is available
	When a GET request is made to '<URL>'
	Then the response status code should be '<ResponseCode>'
	And the response should look like '<ResponseData>'
	Examples: 
	| URL          | ResponseCode | ResponseData                                                                                                                                                                               |
	| 'api/actors' | 200 OK       | [{ "id": 1, "name": "Tom Holland", "bio": "Tom bio","dob": "1990-12-12T00:00:00","sex": "F"},{"id": 2,"name": "Robert",  "bio": "Robert bio",  "dob": "1990-12-12T00:00:00", "sex": "M" }] |

Scenario: Get actor by ID
	Given the service is available
	When a GET request is made to '<URL>'
	Then the response status code should be '<ResponseCode>'
	And the response should look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL            | ResponseCode | ResponseData                                                                                |  
	| 'api/actors/1' | 200 OK       | { "id": 1, "name": "Tom Holland", "bio": "Tom bio","dob": "1990-12-12T00:00:00","sex": "F"} |
	
	@InvalidCase
	Examples:
	| URL            | ResponseCode | ResponseData              |
	| 'api/actors/2' | 404Not Found | Actor with ID 2 not found |
	

Scenario: Create actor
	Given the service is available
	When a POST request is made to '<URL>'
	And  with a request body '<RequestData>'
	Then the response status code should be '<ResponseCode>'
	And the response should look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL          | RequestData                                                                | ResponseCode | ResponseData |
	| 'api/actors' | {"Name": "Tom Holland", "Bio": "Tom bio", "DOB": "1990-12-12", "Sex": "F"} | 200 OK       | 1            |

	@InvalidCase
	Examples:
	| URL          | RequestData                                                                | ResponseCode    | ResponseData                            |
	| 'api/actors' | {"Name": "", "Bio": "Tom bio", "DOB": "1990-12-12", "Sex": "F"}            | 400 Bad Request | Name cannot be empty or null            |
	| 'api/actors' | {"Name": "Tom Holland", "Bio": "", "DOB": "1990-12-12", "Sex": "F"}        | 400 Bad Request | Bio cannot be empty or null             |
	| 'api/actors' | {"Name": "Tom Holland", "Bio": "Tom bio", "DOB": "2023-12-12", "Sex": "F"} | 400 Bad Request | DOB cannot be greater than current date |
	| 'api/actors' | {"Name": "Tom Holland", "Bio": "Tom bio", "DOB": "1990-12-12", "Sex": ""}  | 400 Bad Request | Sex cannot be empty or null             |


Scenario: Update actor
	Given the service is available
	When a PUT request is made to '<URL>'
	And  with a request body '<RequestData>'
	Then the response status code should be '<ResponseCode>'
	And the response should look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL            | RequestData                                                                              | ResponseCode | ResponseData |
	| 'api/actors/1' | {"Name": "Tom Holland", "Bio": "Tom is hollywood star", "DOB": "1990-12-12", "Sex": "M"} | 200 OK       |              |

	@InvalidCase
	Examples:
	| URL            | RequestData                                                                              | ResponseCode    | ResponseData                            |
	| 'api/actors/1' | {"Name": "", "Bio": "Tom bio", "DOB": "1990-12-12", "Sex": "F"}                          | 400 Bad Request | Name cannot be empty or null            |
	| 'api/actors/1' | {"Name": "Tom Holland", "Bio": "", "DOB": "1990-12-12", "Sex": "F"}                      | 400 Bad Request | Bio cannot be empty or null             |
	| 'api/actors/1' | {"Name": "Tom Holland", "Bio": "Tom bio", "DOB": "2023-12-12", "Sex": "F"}               | 400 Bad Request | DOB cannot be greater than current date |
	| 'api/actors/1' | {"Name": "Tom Holland", "Bio": "Tom bio", "DOB": "1990-12-12", "Sex": ""}                | 400 Bad Request | Sex cannot be empty or null             |
	| 'api/actors/2' | {"Name": "Tom Holland", "Bio": "Tom is hollywood star", "DOB": "1990-12-12", "Sex": "M"} | 404 Not Found   | There is no Actor to Update with Id 2   |

Scenario: Delete actor
	Given the service is available
	When a Delete request is made to '<URL>'
	Then the response status code should be '<ResponseCode>'
	And the response should look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL            | ResponseCode | ResponseData |
	| 'api/actors/1' | 200 OK       |              |

	@InValidCase
	Examples:
	| URL            | ResponseCode  | ResponseData                        |
	| 'api/actors/2' | 404 Not Found | NO Actor to Delete with given  ID 2 |

