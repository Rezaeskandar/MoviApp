using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviApp.Data;
using MoviApp.Enteties;
using MoviApp.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MoviApp.Services
{
    public class MovieReposetori : IMoveReposetori
    {
        //inject to cunstruct injection
        private ApiDbContext _context;

        public MovieReposetori(ApiDbContext context)
        {
            //make a null check
            _context = context?? throw new ArgumentException(nameof(context));
        }
      

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.OrderBy(G => G.PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonAsyncById(int PersonId)
        {
            return await _context.Persons.Where(p => p.PersonId == PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonAsyncByName(string Name)
        {
            return await _context.Persons.Where(p => p.Name == Name).ToListAsync();
        }
        public async Task<Genre?> GetAllGenreIncludPersonsAsync(int PersonId)
        {
           
                return await _context.Genres.Include(G => G.PersonGenere).Where(p => p.GenerId == PersonId).FirstOrDefaultAsync();
            
        }
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            //return all Genres Asynctonic
           
                 return await _context.Genres.OrderBy(G => G.GenerId).ToListAsync();
        }

        public async Task<IEnumerable<Genre?>> GetGenreAsyncById(int genreId)
        {
            //return one by id Genres Asynchronous
          
                //Person getPers =new Person();
                //return (IEnumerable<Genre?>)await _context.Genres.Include(p => p.persons).Where(p => p.GenerId == getPers.PersonId).FirstOrDefaultAsync();
                //return await _context.Person.Where(p => p.PersonId == PersonId).ToListAsync();
            
            return await _context.Genres.Where(g => g.GenerId == genreId).ToListAsync();
        }

        public async Task<Genre?> GetGenreAsyncById(int genreId, bool includeGenre)
        {
           
            return await _context.Genres.FindAsync(genreId);
        }
        public async Task<IEnumerable<PersonGenere>> GetPersonsGenreAsync()
        {
            //return all Genres Asynctonic
            return await _context.PersonGenere.OrderBy(G => G.personGenereId).ToListAsync();
        }

        public async Task<Person> GetMovieAsyncByPerson(string PersonName)
        {

            //var person = await _context.Person
            //.Include(p => p.Movies)
            //.FirstOrDefaultAsync(p => p.PersonId == personid);

            //if (person == null)
            //{
            //    return null;
            //}

            //return  person;

            var person = await _context.Persons
        .Join(_context.Movies,
            p => p.PersonId,
            m => m.FkPersonId,
            (p, m) => new { Person = p, Movie = m })
        .Where(x => x.Person.Name == PersonName)
        .Select(x => new Person
        {
            PersonId = x.Person.PersonId,
            Name = x.Person.Name,
            Movies = new List<Movie> { x.Movie }
        })
        .FirstOrDefaultAsync();

            return person;

           
        }

        public async Task<Person> GetRatingAsyncByPerson(string personName)
        {
            //It works make it with include 

            //    return movie;
            //var person = await _context.Persons
            //    .Join(_context.Movies,
            //        p => p.PersonId,
            //        m => m.FkPersonId,
            //        (p, m) => new { Person = p, Movie = m })
            //    .Join(_context.Ratings,
            //        x => x.Movie.MovieId,
            //        r => r.FkMovieId,
            //        (x, r) => new { x.Person, x.Movie, Rating = r })
            //    .Where(x => x.Person.Name == personName)
            //    .GroupBy(x => new { x.Person.PersonId, x.Person.Name })
            //    .Select(g => new Person
            //    {
            //        PersonId = g.Key.PersonId,
            //        Name = g.Key.Name,
            //        Movies = g.GroupBy(x => new { x.Movie.MovieId, x.Movie.Name })
            //                 .Select(gm => new Movie
            //                 {
            //                     MovieId = gm.Key.MovieId,
            //                     Name = gm.Key.Name,
            //                     Rating = gm.Select(x => x.Rating).ToList()
            //                 })
            //                 .ToList()
            //    })
            //    .FirstOrDefaultAsync();

            //return person;

              var person = await _context.Persons
             .Include(p => p.Movies)
             .ThenInclude(m => m.Rating)
             .Where(p => p.Name == personName)
             .Select(p => new Person
            {
                PersonId = p.PersonId,
                Name = p.Name,
                Movies = p.Movies.GroupBy(m => new { m.MovieId, m.Name })
                    .Select(g => new Movie
                    {
                        MovieId = g.Key.MovieId,
                        Name = g.Key.Name,
                        Rating = g.SelectMany(m => m.Rating).ToList()
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

                    return person;
        }

        public async Task<PersonGenere> AddPersonToGenreAsync(int personId, int genreId)
        {
            var person = await _context.Persons.FindAsync(personId);
            var genre = await _context.Genres.FindAsync(genreId);

            if (person == null || genre == null)
            {
                throw new ArgumentException("Invalid person or genre ID.");
            }

            var personGenre = new PersonGenere { Persons = person, Genres = genre };
            await _context.PersonGenere.AddAsync(personGenre);
            await _context.SaveChangesAsync();

            return personGenre;
        }

        public async Task<PersonGenere> AddPersonGenreLinkAsync(int personId, int genreId, string link)
        {
            var person = await _context.Persons.FindAsync(personId);
            var genre = await _context.Genres.FindAsync(genreId);

            if (person == null || genre == null)
            {
                throw new ArgumentException("Invalid person or genre id");
            }

            var newLink = new PersonGenere {FK_personId = personId, FK_GenreId = genreId, NewLinks = link };
            _context.PersonGenere.Add(newLink);
            await _context.SaveChangesAsync();

            return newLink;
        }

        //TMDB
        //private readonly HttpClient _httpClient;

        //public MovieReposetori(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public Task<List<Movie>> GetRecommendedMoviesByGenre(string genre)
        //{
        //    return GetRecommendedMoviesByGenre(genre, _httpClient);
        //}

        //public async Task<List<Movie>> GetRecommendedMoviesByGenre(string genre)
        //{
        //    var url = $"https://api.themoviedb.org/3/discover/movie?api_key=<4830bcf38fe0badbc31f150d78c89f7f>&with_genres={genre}";
        //    var response = await _httpClient.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = await response.Content.ReadAsStringAsync();
        //        var data = JsonSerializer.Deserialize<TMDBMoviesResponse>(result);

        //        return data.Results.Select(x => new Movie
        //        {
        //            Name = x.Name,
        //            Movelink = "", // or set to null or some default value if needed
        //            Rating = null, // or set to an empty list or some default value if needed
        //            //ReleaseDate = x.ReleaseDate
        //        }).ToList();
        //    }

        //    return null;
        //}
        //private readonly ApiDbContext _context;
        private readonly HttpClient _httpClient;

        public MovieReposetori(ApiDbContext context, [FromServices] HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        //public async Task<List<Genre>> GetRecommendedMoviesByGenre(string genre)
        //{
        //    var apiKey = "4830bcf38fe0badbc31f150d78c89f7f";
        //    var url = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&with_genres={genre}";

        //    var response = await _httpClient.GetAsync(url);

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    var result = await response.Content.ReadAsStringAsync();
        //    //    var data = JsonSerializer.Deserialize<TMDBMoviesResponse>(result);

        //    //    if (data != null)
        //    //    {
        //    //        return data.Results.Select(x => new Movie
        //    //        {
        //    //            Name = x.Name,
        //    //            Movelink = "www.Action.com", // or set to null or some default value if needed
        //    //            //Rating = null, // or set to an empty list or some default value if needed
        //    //            //ReleaseDate = x.ReleaseDate
        //    //        }).ToList();
        //    //    }
        //    //    else
        //    //    {
        //    //        return new List<Movie>();
        //    //    }
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = await response.Content.ReadAsStringAsync();
        //        var jsonObject = JsonObject.Parse(result);

        //        //var results = jsonObject.SelectToken("results");
        //        if (result != null)
        //        {
        //            return result.Select(x => new Genre
        //            {
        //                Title = "",
        //                Description = "",
        //                //Rating = null,
        //                //ReleaseDate = x.SelectToken("releaseDate")?.ToString()
        //            }).ToList();
        //        }
        //        else
        //        {
        //            return new List<Genre>();
        //        }
        //    }

        //    return null;
        public async Task<List<Movie>> GetRecommendedMoviesByGenre(string genre)
        {
            try
            {
                var apiKey = "4830bcf38fe0badbc31f150d78c89f7f";
                var url = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&with_genres={genre}";
                var response = await _httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<TMDBMoviesResponse>(content, options);
                return result?.Results ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                // Handle the exception here, for example log it
                Console.WriteLine($"An error occurred while retrieving recommended movies: {ex.Message}");
                return null; // or an empty list
            }
        }
    }

       
    
     
}
