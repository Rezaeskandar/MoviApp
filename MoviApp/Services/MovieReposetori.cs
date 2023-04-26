using Microsoft.EntityFrameworkCore;
using MoviApp.Data;
using MoviApp.Models;

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
            return await _context.Person.OrderBy(G => G.PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonAsyncById(int PersonId)
        {
            return await _context.Person.Where(p => p.PersonId == PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonAsyncByName(string Name)
        {
            return await _context.Person.Where(p => p.Name == Name).ToListAsync();
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

                var person = await _context.Person
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

    

        //public async Task<IEnumerable<Genre?>> GetGenreAsync(int genreId, bool includGenre)
        //{
        //    //return one by id Genres Asynchronous
        //    return await _context.Genres.Where(g => g.GenerId == genreId).ToListAsync();
        //}

    }
}
