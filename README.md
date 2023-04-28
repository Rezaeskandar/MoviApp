## Movie Recommendation System

> *This is a backend application for a movie recommendation system. The system allows you to manage persons, genres, movies, and ratings. You can also use an external API, like TMDB, to get movie recommendations.This is a backend application for a movie recommendation system. The system allows you to manage persons, genres, movies, and ratings. You can also use an external API, like TMDB, to get movie recommendations.*

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
