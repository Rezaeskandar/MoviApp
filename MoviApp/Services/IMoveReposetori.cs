using MoviApp.Models;

namespace MoviApp.Services
{
    public interface IMoveReposetori
    {

       Task< IEnumerable<Person>> GetPersonsAsync();
       Task<IEnumerable<Person?>> GetPersonAsyncById(int PersonId, bool includGenre);
        //Task<IEnumerable<Person?>> GetPersonsAsync(int PersonId);
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<IEnumerable<Genre?>> GetGenreAsyncById(int GenreId, bool includPerson);

        //Task<IEnumerable<PersonGenere>> GetPersonsGenreAsync();
        Task<IEnumerable<PersonGenere?>> GetPersonsGenreAsync(int PersonGenreId, bool includPerson);
        //Task GetGenreAsync(int id, bool includPerson);
        //Task GetGenreAsyncById(int id, bool includPerson);

        //Task<IEnumerable<Movie>> GetMovieAsync();
        //Task<IEnumerable<Movie?>> GetMovieAsync(int PersonId);
    }
}
 
