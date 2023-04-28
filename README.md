## Movie Recommendation System

> *This is a backend application for a movie recommendation system API. The system allows you to manage persons, genres, movies, and ratings. You can also use an external API, like TMDB, to get movie recommendations. I have built a Movie Recommendation System using ASP.NET Core Web API (MVC) and Entity Framework Core. Throw the API you are allowed to manipulate the data from the database. The system is structured with a code-first approach using the repository pattern for data access. movies, genres, and ratings, and relationships are established through foreign keys. I chose this approach as it allows for easy maintenance and scalability of the system. While there may be alternative approaches, I believe this structure best fits the needs of the project.*

___

## Installation

Clone the repository to your local machine:
- git clone https://github.com/Rezaeskandar/movie-recommendation-system.git
> Clone the repository to your local machine
Open the solution file in Visual Studio
Create a new SQL Server database and update the connection string in the appsettings.json file
Run the Update-Database command in the Package Manager Console to create the database schema
Obtain an API key from TMDB and update the TMDBApiKey value in the appsettings.json file
Build and run the project

___

## Technologies Used
- ASP.NET Core 6 (MVC)
- Entity Framework Core 6
- SQL Server
- Linq
- TMDB API
___

## Features
- Get all users in the system
- Get all genres with a specific user
- Get all movies with a specific user
- Add and get movie ratings for a specific user
- Associate a user with a new genre
- Add new links for a specific user and a specific genre
- Get movie recommendations for a specific user based on their viewing history and preferences

___

##Usage
The following endpoints are available for interacting with the API:

- GET /Genre - Returns a list of all Genres 
- GET /Genre/{id} - Returns a list of all genres with the specified user
- GET /Person - Returns a list of all Persons 
- GET /Person/{id} - Returns a list of all Person with the specified user
- GET /Person/{Name} - Returns a list of all Person with the specified name
- GET /GetMovieByPerson - Returns a list of all movies with the specified person
- GET /GetRatingByPersonName - Returns a list of all Rationgs with the specified person
- POST /add-person-to-genre - Add a specified user with a new genre
- POST /Add-NewLink/{personId}/genre/{genreId}/link - Adds a new link for the specified user and genre

___
If you would like to contribute to this project, please fork the repository and submit a pull request. All contributions are welcome!
