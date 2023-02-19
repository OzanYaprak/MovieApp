using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    // controller
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
                new Movie {Title="film 1",Description="açıklama 1", Director="Yönetmen 1", Casts=new string[] {"oyuncu 1","oyuncu 2"}},
                new Movie {Title="film 2",Description="açıklama 2", Director="Yönetmen 2", Casts=new string[] {"oyuncu 1","oyuncu 2"}},
                new Movie {Title="film 3",Description="açıklama 3", Director="Yönetmen 3", Casts=new string[] {"oyuncu 1","oyuncu 2"}}
            };
            return View(filmListesi);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
