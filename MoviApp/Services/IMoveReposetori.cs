using MoviApp.Enteties;
using MoviApp.Models;

namespace MoviApp.Services
{
    public interface IMoveReposetori
    {

       Task< IEnumerable<Person>> GetPersonsAsync();
       Task<IEnumerable<Person?>> GetPersonAsyncById(int PersonId);
        Task<IEnumerable<Person?>> GetPersonAsyncByName(string Name);
        Task<Genre?> GetAllGenreIncludPersonsAsync(int PersonId);
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<IEnumerable<Genre?>> GetGenreAsyncById(int GenreId);
        Task<Genre?> GetGenreAsyncById(int GenreId, bool includPerson);
      
        Task<IEnumerable<PersonGenere?>> GetPersonsGenreAsync();
       

        Task<Person?> GetMovieAsyncByPerson(string PersonName);
        Task<Person?> GetRatingAsyncByPerson(string personName );

        Task<PersonGenere?> AddPersonToGenreAsync(int personId, int genreId);

        Task<PersonGenere?> AddPersonGenreLinkAsync(int personId, int genreId, string NewLink);
        
    }
}
 
