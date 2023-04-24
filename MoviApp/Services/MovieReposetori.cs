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

        public async Task<IEnumerable<Person?>> GetPersonAsyncById(int PersonId, bool includPerson)
        {
            return await _context.Person.Where(p => p.PersonId == PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            //return all Genres Asynctonic
            return await _context.Genres.OrderBy(G => G.GenerId).ToListAsync();
        }

        public async Task<IEnumerable<Genre?>> GetGenreAsyncById(int genreId, bool includGenre)
        {
            //return one by id Genres Asynchronous
            return await _context.Genres.Where(g => g.GenerId == genreId).ToListAsync();
        }

        public async Task<IEnumerable<PersonGenere>> GetPersonsGenreAsync(int PersonGenreId, bool includPerson )
        {
            //return all Genres Asynctonic
            return await _context.PersonGenere.OrderBy(G => G.personGenereId).ToListAsync();
        }

        //public async Task<IEnumerable<Genre?>> GetGenreAsync(int genreId, bool includGenre)
        //{
        //    //return one by id Genres Asynchronous
        //    return await _context.Genres.Where(g => g.GenerId == genreId).ToListAsync();
        //}

    }
}
