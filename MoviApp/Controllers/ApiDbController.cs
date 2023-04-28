using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviApp.Enteties;
using MoviApp.Models;
using MoviApp.Services;

namespace MoviApp.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class ApiDbController : ControllerBase
    {

        private readonly IMoveReposetori _moveReposetori;

        private readonly IMapper _mapper;
        // GET: ApiDbController
        // Injection

        public ApiDbController(IMoveReposetori moveReposetori,IMapper mapper)
        {
            _moveReposetori = moveReposetori
                ?? throw new ArgumentNullException(nameof(moveReposetori));
            _mapper = mapper;
        }
        [HttpGet("Genre")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGnres()
        {
            //get genere genom reposetories
            var genreEntity = await _moveReposetori.GetGenresAsync();


            //mapping from genreEntity to Genre
            //var resoult = new List<Genre>();
            //foreach (var Genre in genreEntity)
            //{
            //    resoult.Add(new Genre
            //    {
            //        GenerId = Genre.GenerId,
            //        Title = Genre.Title,
            //        Description = Genre.Description,
            //        persons = Genre.persons

            //    });
            //}
            //return Ok(resoult);
           return Ok(_mapper.Map<List<Genre>>(genreEntity));
        }

        //[HttpPost("Genre")]
        //public async Task<ActionResult<IEnumerable<Genre>>> GetGnres()
        //{
        //    //get genere genom reposetories
        //    var genreEntity = await _moveReposetori.GetGenresAsync();


            
        //    return Ok(_mapper.Map<List<Genre>>(genreEntity));
        //}
        //    return Ok(resoult);
        //}
        [HttpGet("Genre/{id}")]
        public async Task<ActionResult<Genre>> GetGnresById(int id)
        {
            //get genere genom reposetories
            var genreEntity = await _moveReposetori.GetGenreAsyncById(id);

            if (genreEntity == null)
            {
                return NotFound();
            }

            //if (includPerson)
            //{
            //    var resoult1 = new Genre
            //    {
            //        GenerId = genreEntity.GenerId,
            //        Title = genreEntity.Title,
            //        Description = genreEntity.Description,
            //        persons = genreEntity.persons
            //    };

            //    return Ok(resoult1);
            //}

            //return Ok(genreEntity);
            return Ok(_mapper.Map<List<Genre>>(genreEntity));
        }

        // get persons
        [HttpGet("person")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPesrons()
        {
            //get genere genom reposetories
            var PersonEntity = await _moveReposetori.GetPersonsAsync();

            return Ok(_mapper.Map<List<Person>>(PersonEntity));
        }


        //get person By Id

        [HttpGet("person{id}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetUniqPerson(int id)
        {
            //get genere genom reposetories
            var personEntity = await _moveReposetori.GetPersonAsyncById(id);
            //var persEntity = await _moveReposetori.GetPersonAsyncById(id, includPerson);
            if (personEntity == null)
            {
                return NotFound();
            }

            
                return Ok(_mapper.Map<List<Person>>(personEntity));

            
            //mapping from genreEntity to Genre
            //var resoult = new List<Person>();
            //foreach (var peron in personEntity)
            //{
            //    resoult.Add(new Person
            //    {
            //        PersonId = peron.PersonId,
            //        Name = peron.Name,
            //        Email = peron.Email
            //    });
            //}
            //return Ok(resoult);
           
        }

        //get person by name

        [HttpGet("GetPersonBy/{Name}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByName(string Name)
        {
            //get genere genom reposetories
            var personEntity = await _moveReposetori.GetPersonAsyncByName(Name);
            //var persEntity = await _moveReposetori.GetPersonAsyncById(id, includPerson);
            if (personEntity == null)
            {
                return NotFound();
            }

            if (personEntity != null)
            {
                return Ok(_mapper.Map<List<Person>>(personEntity));

            }
           
                return NotFound("Name You searching not exist!");

            
            //return Ok(_mapper.Map<List<Person>>(personEntity));
        }

       

        [HttpGet("GetMovieByPerson")]
        public async Task<ActionResult<Person>> GetMovieAsync(string PersonName)
        {
            var personEntity = await _moveReposetori.GetMovieAsyncByPerson(PersonName);
            if (personEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Person>(personEntity));
        }


        [HttpGet("GetRatingByPersonName")]
        public async Task<ActionResult<Person>> GetRatingByMovieID(string personName)
        {
            var movieEntity = await _moveReposetori.GetRatingAsyncByPerson(personName);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Person>(movieEntity));

        }

        [HttpPost("add-person-to-genre")]
        public async Task<ActionResult<PersonGenere>> AddPersonToGenre(int personId, int genreId)
        {
            await _moveReposetori.AddPersonToGenreAsync(personId, genreId);

            return Ok();
        }


        [HttpPost("Add-NewLink/{personId}/genre/{genreId}/link")]
        public async Task<ActionResult<PersonGenere>> AddPersonGenreLink(int personId, int genreId, [FromBody] string link)
        {
            var newPersonGenre = await _moveReposetori.AddPersonGenreLinkAsync(personId, genreId, link);
            return Ok(newPersonGenre);
        }
    }



}
