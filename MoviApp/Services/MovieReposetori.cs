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
        public async Task<IEnumerable<Genre>> GetGenreAsync()
        {
            //return all Genres Asynctonic
            return await _context.Genres.OrderBy(G => G.GenerId).ToListAsync();
        }

        public async Task<IEnumerable<Genre?>> GetGenreAsync(int genreId)
        {
            //return one by id Genres Asynchronous
            return await _context.Genres.Where(g => g.GenerId == genreId).ToListAsync();
        }


        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Person.OrderBy(G => G.PersonId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonsAsync(int PersonId)
        {
            return await _context.Person.Where(p => p.PersonId == PersonId).ToListAsync();
        }
    }
}
