using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System.Collections.Generic;

namespace MovieApp.Web.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var turListesi = new List<Genre>()
            {
                new Genre {GenreName="Macera"},
                new Genre {GenreName="Komedi"},
                new Genre {GenreName="Romantik"},
                new Genre {GenreName="Savaş"},
            };

            return View(turListesi);
        }
    }
}
