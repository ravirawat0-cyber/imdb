
# IMDb Project Documentation

## Overview

The IMDb project is a web application designed to manage information about movies, actors, producers, genres, and reviews. It provides a RESTful API for performing CRUD operations on these entities.

## Technologies Used

- **ASP.NET Core**: Framework for building web applications and APIs.
- **Azure**: Cloud platform used for hosting and deploying the application.
- **MySQL**: Relational database management system for storing data.
- **SpecFlow**: Framework for Behavior-Driven Development (BDD) testing.
- **Moq**: Framework for mocking objects in unit tests.
- **Dapper**: Micro ORM (Object-Relational Mapper) used for data access.
- **C#**: Programming language used for backend development.
- **Dependency Injection (DI)**: Pattern used for managing object dependencies.
- **RESTful APIs**: Architectural style for designing networked applications.
- **Swagger**: Tool for documenting and testing APIs.

## Project Structure

The IMDb project consists of the following components:

1. **Controllers**:
    - ActorsController
    - GenresController
    - MoviesController
    - ProducersController
    - ReviewsController

2. **Interfaces**:
    - IActorServices
    - IGenreServices
    - IMovieServices
    - IProducerServices
    - IReviewServices

3. **Models**:
    - DbModels (Entities representing database tables)
    - Request (Request models for creating entities)
    - Response (Response models for returning data)

4. **Services**:
    - ActorServices
    - GenreServices
    - MovieServices
    - ProducerServices
    - ReviewServices

5. **Other**:
    - Firebase Storage Integration for uploading movie cover images.

## Functionality

### Actors Controller
- Get all actors
- Get actor by ID
- Create new actor
- Update actor
- Delete actor

### Genres Controller
- Get all genres
- Get genre by ID
- Create new genre
- Update genre
- Delete genre

### Movies Controller
- Get all movies
- Get movie by ID
- Create new movie
- Update movie
- Delete movie
- Upload movie cover image

### Producers Controller
- Get all producers
- Get producer by ID
- Create new producer
- Update producer
- Delete producer

### Reviews Controller
- Get all reviews for a movie
- Get review by ID
- Create new review for a movie
- Update review
- Delete review

## Testing

The IMDb project includes unit tests and integration tests using Moq and SpecFlow for ensuring the correctness of functionalities.

## Deployment

The application is deployed on Azure, utilizing Azure services for hosting and managing the application.

## API Documentation

Swagger is integrated into the project, providing comprehensive API documentation and allowing users to test the endpoints directly from the browser.

## Conclusion

The IMDb project provides a robust platform for managing movie-related information through a RESTful API, with extensive testing, documentation, and deployment strategies in place.
