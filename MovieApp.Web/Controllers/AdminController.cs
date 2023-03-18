using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model, int[] genreId, IFormFile file)
        {
            var entity = _context.Movies.Include(a => a.Genres).FirstOrDefault(a => a.MovieID == model.MovieID);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = model.Title;
            entity.Description = model.Description;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var fileName = string.Format($"ozanyaprak{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);

                entity.ImageURL = fileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }

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
                .Select(a => new AdminGenreEditViewModel
                {
                    GenreID = a.GenreID,
                    GenreName = a.GenreName,
                    Movies = a.Movies.Select(a => new AdminMovieViewModel
                    {
                        MovieID = a.MovieID,
                        Title = a.Title,
                        ImageURL = a.ImageURL,
                    }).ToList()
                })
                .FirstOrDefault(a => a.GenreID == id);

            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieid)
        {
            var entity = _context.Genres.Include(a => a.Movies).FirstOrDefault(a => a.GenreID == model.GenreID);

            if (entity == null)
            {
                return NotFound();
            }

            entity.GenreName = model.GenreName;

            foreach (var id in movieid)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(a => a.MovieID == id));
            }


            _context.SaveChanges();


            return RedirectToAction("GenreList");

        }



        [HttpPost]
        public IActionResult GenreDelete(int genreid)
        {
            var entity = _context.Genres.Find(genreid);

            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("GenreList");
        }



        [HttpPost]
        public IActionResult MovieDelete(int movieid)
        {
            var entity = _context.Movies.Find(movieid);

            if (entity != null)
            {
                _context.Movies.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }




        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();

            return View();
        }



        [HttpPost]
        public IActionResult MovieCreate(Movie m, int[] genreid)
        {
            if (ModelState.IsValid)
            {
                m.Genres = new List<Genre>();

                foreach (var id in genreid)
                {
                    m.Genres.Add(_context.Genres.FirstOrDefault(a => a.GenreID == id));
                }


                _context.Movies.Add(m);
                _context.SaveChanges();

                return RedirectToAction("MovieList");
            }


            ViewBag.Genres = _context.Genres.ToList();

            return View();
        }
    }
}
