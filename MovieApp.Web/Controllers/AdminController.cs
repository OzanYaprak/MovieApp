using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.ViewModels;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly movieContext _context;

        public AdminController(movieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                .Include(a => a.Genres)
                .Select(a => new AdminMovieViewModel
                {
                    MovieID = a.MovieID,
                    Title = a.Title,
                    ImageURL = a.ImageURL,
                    Genres = a.Genres

                }).ToList()
            });
        }


        [HttpGet]
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Movies.Select(a => new AdminEditMovieViewModel
            {

                MovieID = a.MovieID,
                Title = a.Title,
                ImageURL = a.ImageURL,
                Description = a.Description,
                SelectedGenres = a.Genres

            }).FirstOrDefault(a => a.MovieID == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }



        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model)
        {
            var entity = _context.Movies.Find(model.MovieID);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageURL = model.ImageURL;

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
