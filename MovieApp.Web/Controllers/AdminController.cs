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
                .Include(a=>a.Genres)
                .Select(a=>new AdminMovieViewModel 
                {
                    MovieID = a.MovieID,
                    Title = a.Title,
                    ImageURL = a.ImageURL,
                    Genres = a.Genres

                }).ToList()
            });
        }
    }
}
