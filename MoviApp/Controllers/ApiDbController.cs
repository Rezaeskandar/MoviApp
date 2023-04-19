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
        public async Task <ActionResult<IEnumerable<Genre>>> GetGnres()
        {
            //get genere genom reposetories
            var genreEntity = await _moveReposetori.GetGenreAsync();

            //mapping from genreEntity to Genre
            var resoult  = new List<Genre>();
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
    }
}
