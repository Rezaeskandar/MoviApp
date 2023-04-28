using Microsoft.EntityFrameworkCore;
using MoviApp.Data;
using MoviApp.Enteties;
using MoviApp.Models;
using System.Linq;

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

            //var existingLink = await _context.PersonGenere
            //    .FirstOrDefaultAsync(pgl => pgl.FK_personId == personId && pgl.FK_GenreId == genreId);

            //if (existingLink != null)
            //{
            //    throw new InvalidOperationException("Link already exists");
            //}

            var newLink = new PersonGenere {FK_personId = personId, FK_GenreId = genreId, NewLinks = link };
            _context.PersonGenere.Add(newLink);
            await _context.SaveChangesAsync();

            return newLink;
        }
    }   
}
