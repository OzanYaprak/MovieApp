using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string filmBasligi = "film başlığı";
            string filmAciklama = "film açıklaması";
            string filmYonetmen = "film yönetmen adı";
            string[] oyunculuar = { "oyuncu 1", "oyuncu 2" };

            var m = new Movie();

            m.Title = filmBasligi;
            m.Description = filmAciklama;
            m.Director = filmYonetmen;
            m.Casts = oyunculuar;
            m.ImageURL = "1.jpg";

            return View(m);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
