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

        //[HttpGet("Genre{id}")]
        //public async Task<ActionResult<Genre>> GetGnresById(int id, bool includPerson = false)
        //{
        //    //get genere genom reposetories
        //    var genreEntity = await _moveReposetori.GetGenreAsyncById(id, includPerson);
        //    //var persEntity = await _moveReposetori.GetPersonAsyncById(id, includPerson);
        //    if (genreEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    if (includPerson)
        //    {
        //        var resoult1 = new Genre();
        //        //foreach (var Genre in genreEntity)
        //        //{
        //       new Genre
        //        {
        //            GenerId = genreEntity.GenerId,
        //            Title = genreEntity.Title,
        //            Description = genreEntity.Description,
        //            //persons = Genre.persons
        //        };
        //            //var rePers = new List<Person>();
        //            //foreach (var Person in persEntity)
        //            //{
        //            //    rePers.Add(new Person { PersonId = Person.PersonId, Name = Person.Name, Email = Person.Email });
        //            //}
        //            //return Ok(rePers);
        //        //}

        //        return Ok(resoult1);
        //    }
        //    //mapping from genreEntity to Genre
        //    var resoult = new Genre();
        //    //foreach (var Genre in resoult)
        //    //{
        //        new Genre
        //        {
        //            GenerId = genreEntity.GenerId,
        //            Title = genreEntity.Title,
        //            Description = genreEntity.Description
        //        };
        //    //}
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
            return Ok(_mapper.Map<List<Person>>(personEntity));
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

        //Get person genre
        //[HttpGet("PersonGenre")]
        //public async Task<ActionResult<IEnumerable<PersonGenere>>> GetPersonGnres()
        //{
        //    //get genere genom reposetories
        //    var personGenreEntity = await _moveReposetori.GetPersonsGenreAsync();

        //    //mapping from genreEntity to Genre
        //    var resoult = new List<PersonGenere>();
        //    foreach (var personGenre in personGenreEntity)
        //    {
        //        resoult.Add(new PersonGenere
        //        {
        //           personGenereId = personGenre.personGenereId,
        //           FK_GenreId = personGenre.FK_GenreId,
        //           FK_personId= personGenre.FK_personId

        //        });
        //    }
        //    return Ok(resoult);
        //}

        //[HttpGet("GEtgenres/{personId}")]
        //public async Task<ActionResult<GnreIncludPerson>> GetGenresForPerson(int personId , bool includeGnre)
        //{
        //    var personGEntity = await _moveReposetori.GetAllGenreIncludPersonsAsync(personId, includeGnre);

        //    var resoult3 = new List<GnreIncludPerson>();
        //    foreach (var personGenre in personGEntity)
        //    {
        //        resoult3.Add(new GnreIncludPerson
        //        {
        //            Id = personGenre.Id,
        //            Name = personGenre.Name,
        //            Description = personGenre.Description

        //        });
        //    }

        //    //var genres = Person.PersonGenres.Select(pg => pg.Genre).ToList();

        //    //return Ok(genres);
        //}  

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
    }



}
