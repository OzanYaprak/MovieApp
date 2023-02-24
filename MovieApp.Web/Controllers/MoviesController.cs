using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(int? id, string arama)
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];
            //var kelime = HttpContext.Request.Query["arama"].ToString(); //query den gelen arama


            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(a => a.GenreID == id).ToList();
            }


            //arama kısmı için
            if (!string.IsNullOrEmpty(arama)) // boş olmayıp bir değer olduğunda çalışmasını (!) sağlıyoruz.
            {
                movies = movies.Where(a => a.Title.ToLower().Contains(arama.ToLower()) || a.Description.ToLower().Contains(arama.ToLower())).ToList(); //tolower arama kısmına yazılan büyük harfli kelimeleri otomatik olarak küçük harf e çeviriyor.
            }


            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie ekle)
        {
            //var ekle = new Movie()
            //{
            //    Title= title,
            //    Description= description,
            //    Director= director,
            //    ImageURL= imageurl,
            //    GenreID= genreid
            //};
            // YUKARIDAKİ KISMI CREATE POSTUNUN İÇERİSİNE PARAMETRE OLARAKDA EKLEYEBİLİRİZ FAKAT BİR DİĞER YÖNTEM İSE BİZİM ZATEN CREATE VİEW I İÇERİSİNDE EKLEMİŞ OLDUĞUMUZ NAME KISIMLARI, MOVİE CLASS I İÇİNDEKİ PARAMETRELER İLE AYNI OLDUĞU İÇİN BURADA CREATE POST KISMININ PARAMETRESİNE Movie ekle YAZARSAK OTOMATİK OLARAK MOVİE CLASSINDAKİ PARAMETRELERİ ekle NİN İÇERİSİNE ATIYOR OLACAK.

            if (ModelState.IsValid)
            {
                MovieRepository.Add(ekle);
                TempData["Message"] = $"{ekle.Title} isimli film eklendi.";
                return RedirectToAction("List", "Movies");
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName");
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName");
            return View(MovieRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie duzenle)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(duzenle);
                TempData["Message"] = $"{duzenle.Title} isimli film güncellendi.";
                return RedirectToAction("Details", "Movies", new { @id = duzenle.MovieID });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName");
            return View(duzenle);
        }


        [HttpPost]
        public IActionResult Delete(int movieid, string title)
        {
            MovieRepository.Delete(movieid);
            TempData["Message"] = $"{title} isimli film silindi.";
            return RedirectToAction("List", "Movies");
        }
    }
}
