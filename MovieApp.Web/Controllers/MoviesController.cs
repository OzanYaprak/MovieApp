using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using MovieApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{

    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var filmListesi = new List<Movie>() 
            {
                new Movie {Title="film 1",Description="açıklama 1", Director="Yönetmen 1", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL="1.jpg"},
                new Movie {Title="film 2",Description="açıklama 2", Director="Yönetmen 2", Casts=new string[] {"oyuncu 1","oyuncu 2"},ImageURL="2.jpg"},
                new Movie {Title="film 3",Description="açıklama 3", Director="Yönetmen 3", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL = "3.jpg"}
            };

            var turListesi = new List<Genre>()
            {
                new Genre {GenreName="Macera"},
                new Genre {GenreName="Komedi"},
                new Genre {GenreName="Romantik"},
                new Genre {GenreName="Savaş"},
            };

            var model = new MovieGenreViewModel()
            {
                Movies = filmListesi,
                Genres = turListesi
            };

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
