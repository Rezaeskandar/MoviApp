using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviApp.Models;
using MoviApp.Services;

namespace MoviApp.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class ApiDbController : ControllerBase
    {

        private readonly IMoveReposetori _moveReposetori;


        // GET: ApiDbController
        // Injection

        public ApiDbController(IMoveReposetori moveReposetori)
        {
            _moveReposetori = moveReposetori
                ?? throw new ArgumentNullException(nameof(moveReposetori));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGnres()
        {
            //get genere genom reposetories
            var genreEntity = await _moveReposetori.GetGenresAsync();

            //mapping from genreEntity to Genre
            var resoult = new List<Genre>();
            foreach (var Genre in genreEntity)
            {
                resoult.Add(new Genre
                {
                    GenerId = Genre.GenerId,
                    Title = Genre.Title,
                    Description = Genre.Description,
                    persons = Genre.persons

                });
            }
            return Ok(resoult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGnresById(int id, bool includPerson = false)
        {
            //get genere genom reposetories
            var genreEntity = await _moveReposetori.GetGenreAsyncById(id, includPerson);
            //var persEntity = await _moveReposetori.GetPersonAsyncById(id, includPerson);
            if (genreEntity == null)
            {
                return NotFound();
            }

            if (includPerson)
            {
                var resoult1 = new List<Genre>();
                foreach (var Genre in genreEntity)
                {
                    resoult1.Add(new Genre
                    {
                        GenerId = Genre.GenerId,
                        Title = Genre.Title,
                        Description = Genre.Description
                    });
                    //var rePers = new List<Person>();
                    //foreach (var Person in persEntity)
                    //{
                    //    rePers.Add(new Person { PersonId = Person.PersonId, Name = Person.Name, Email = Person.Email });
                    //}
                    //return Ok(rePers);
                }

                return Ok(resoult1);
            }
            //mapping from genreEntity to Genre
            var resoult = new List<Genre>();
            foreach (var Genre in genreEntity)
            {
                resoult.Add(new Genre
                {
                    GenerId = Genre.GenerId,
                    Title = Genre.Title,
                    Description = Genre.Description
                });
            }
            return Ok(resoult);
        }

        // get persons
        [HttpGet("person")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPesrons()
        {
            //get genere genom reposetories
            var PersonEntity = await _moveReposetori.GetPersonsAsync();

            //mapping from genreEntity to Genre
            var resoult = new List<Person>();
            foreach (var person in PersonEntity)
            {
                resoult.Add(new Person
                {
                  PersonId = person.PersonId,
                  Name= person.Name,
                  Email= person.Email

                });
            }
            return Ok(resoult);
        }


        //get person By Id

        [HttpGet("person{id}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetUniqPerson(int id, bool includGenre = false)
        {
            //get genere genom reposetories
            var personEntity = await _moveReposetori.GetPersonAsyncById(id, includGenre);
            //var persEntity = await _moveReposetori.GetPersonAsyncById(id, includPerson);
            if (personEntity == null)
            {
                return NotFound();
            }

            if (includGenre)
            {
                var resoult1 = new List<Person>();
                foreach (var peron in personEntity)
                {
                    resoult1.Add(new Person
                    {
                      PersonId = peron.PersonId,
                      Name= peron.Name,
                      Email= peron.Email
                    });
                    //var rePers = new List<Person>();
                    //foreach (var Person in persEntity)
                    //{
                    //    rePers.Add(new Person { PersonId = Person.PersonId, Name = Person.Name, Email = Person.Email });
                    //}
                    //return Ok(rePers);
                }

                return Ok(resoult1);
            }
            //mapping from genreEntity to Genre
            var resoult = new List<Person>();
            foreach (var peron in personEntity)
            {
                resoult.Add(new Person
                {
                    PersonId = peron.PersonId,
                    Name = peron.Name,
                    Email = peron.Email
                });
            }
            return Ok(resoult);
        }
    }


    //////get all person
    //[HttpGet("{id}")]
    //public async Task<ActionResult<IEnumerable<PersonGenere>>> GetPersonsGenreAsync(int id, bool includPerson =false)
    //{
    //    var persGenreEntity = await _moveReposetori.GetPersonsGenreAsync(id, includPerson);
    //    //get genere genom reposetories

    //    if (includPerson)
    //    {
    //        var resoult = new List<PersonGenere>();
    //        foreach (var PersonGen in persGenreEntity)
    //        {
    //            resoult.Add(new PersonGenere
    //            {
    //                personGenereId = PersonGen.personGenereId,
    //                FK_Gener = PersonGen.FK_Gener,
    //                FK_person = PersonGen.FK_person,
    //                liked = PersonGen.liked


    //            });
    //        }
    //        return Ok(resoult);
    //    }
    //    //mapping from genreEntity to person



    //}

    //// GET: ApiDbController/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: ApiDbController/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: ApiDbController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: ApiDbController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: ApiDbController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: ApiDbController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: ApiDbController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
    //}
}
