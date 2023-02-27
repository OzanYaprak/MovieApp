using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{

    public class MoviesController : Controller
    {
        private readonly movieContext _context;

        public MoviesController(movieContext context)
        {
            _context = context;
        }




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


            //var movies = MovieRepository.Movies;
            var movies = _context.Movies.AsQueryable();
            if (id != null)
            {
                movies = movies.Include(a => a.Genres).Where(a => a.Genres.Any(g => g.GenreID == id));
            }


            //arama kısmı için
            if (!string.IsNullOrEmpty(arama)) // boş olmayıp bir değer olduğunda çalışmasını (!) sağlıyoruz.
            {
                movies = movies.Where(a => a.Title.ToLower().Contains(arama.ToLower()) || a.Description.ToLower().Contains(arama.ToLower())); //tolower arama kısmına yazılan büyük harfli kelimeleri otomatik olarak küçük harf e çeviriyor.
            }


            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //return View(MovieRepository.GetById(id)); ESKİ 

            return View(_context.Movies.Find(id));
        }



        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName"); ESKİ
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreID", "GenreName");
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
                //MovieRepository.Add(ekle); EKİ YÖNTEM REPO KULLANIRKEN YAPILAN

                _context.Movies.Add(ekle);
                _context.SaveChanges();
                TempData["Message"] = $"{ekle.Title} isimli film eklendi.";
                return RedirectToAction("List", "Movies");
            }
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName"); ESKİ
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreID", "GenreName");
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName"); ESKİ
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreID", "GenreName");
            return View(_context.Movies.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie duzenle)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(duzenle); ESKİ
                _context.Movies.Update(duzenle);
                _context.SaveChanges();
                TempData["Message"] = $"{duzenle.Title} isimli film güncellendi.";
                return RedirectToAction("Details", "Movies", new { @id = duzenle.MovieID });
            }
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreID", "GenreName"); ESKİ
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreID", "GenreName");
            return View(duzenle);
        }


        [HttpPost]
        public IActionResult Delete(int movieid, string title)
        {
            //MovieRepository.Delete(movieid); ESKİ
            var entity = _context.Movies.Find(movieid);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{title} isimli film silindi.";
            return RedirectToAction("List", "Movies");
        }
    }
}
