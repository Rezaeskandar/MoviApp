using MoviApp.Models;

namespace MoviApp.Services
{
    public interface IMoveReposetori
    {
       Task< IEnumerable<Person>> GetPersonsAsync();
       Task<IEnumerable<Person?>> GetPersonsAsync(int PersonId);

        Task<IEnumerable<Genre>> GetGenreAsync();
        Task<IEnumerable<Genre?>> GetGenreAsync(int GenreId);
    }
}

