using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.ViewModels;
using System.Collections.Generic;
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
        public IActionResult MovieUpdate(AdminEditMovieViewModel model, int[] genreId)
        {
            var entity = _context.Movies.Include(a => a.Genres).FirstOrDefault(a => a.MovieID == model.MovieID);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageURL = model.ImageURL;
            entity.Genres = genreId.Select(id => _context.Genres.FirstOrDefault(a => a.GenreID == id)).ToList();

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }



        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(a => new AdminGenreViewModel
                {
                    GenreID = a.GenreID,
                    GenreName = a.GenreName,
                    Count = a.Movies.Count

                }).ToList()
            });
        }



        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Genres
                .Select(a=> new AdminGenreEditViewModel
                {
                    GenreID=a.GenreID,
                    GenreName=a.GenreName,
                    Movies = a.Movies.Select(a=> new AdminMovieViewModel
                    {
                        MovieID=a.MovieID,
                        Title = a.Title,
                        ImageURL = a.ImageURL,
                    }).ToList()
                })
                .FirstOrDefault(a=>a.GenreID == id);

            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        } 
        













    }
}
